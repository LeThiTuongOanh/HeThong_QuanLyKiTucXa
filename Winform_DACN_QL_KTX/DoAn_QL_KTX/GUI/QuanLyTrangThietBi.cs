using GUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using DTO;
using BLL;
using Control;
using OfficeOpenXml;


namespace GUI
{
    public partial class QuanLyTrangThietBi : Form
    {
        private BLL_TrangThietBi bll_ttb;
        public BLL_NhaCungCap bll_ncc;

        public QuanLyTrangThietBi()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; 
            this.Load += QuanLyTrangThietBi_Load;
            bll_ttb = new BLL_TrangThietBi();
            bll_ncc = new BLL_NhaCungCap();
            dataGV_TrangThietBi.CellClick += DataGV_TrangThietBi_CellClick;
            cbo_MaPhong.SelectedIndexChanged += Cbo_MaPhong_SelectedIndexChanged;
            cbo_Ten_TTB.SelectedIndexChanged += Cbo_Ten_TTB_SelectedIndexChanged;
            dataGV_CT_TrangThietBi.CellClick += DataGV_CT_TrangThietBi_CellClick;
            comboBoxTinhThanh.SelectedIndexChanged += ComboBoxTinhThanh_SelectedIndexChanged;
            comboBoxHuyen.SelectedIndexChanged += ComboBoxHuyen_SelectedIndexChanged;
            cbo_TenNhaCungCap.SelectedIndexChanged += Cbo_TenNhaCungCap_SelectedIndexChanged;
            data_GV_CT_DonNhap.CellClick += Data_GV_CT_DonNhap_CellClick;
            ////
            btn_Them_DSNhap.Click += Btn_Them_DSNhap_Click;

            btn_LuuPhieuNhap.Click += Btn_LuuPhieuNhap_Click;

            btn_HoaDonNhap.Click += Btn_HoaDonNhap_Click;
            dataGV_DS_DonNhap.CellClick += DataGV_DS_DonNhap_CellClick;

        }

        private void DataGV_DS_DonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra nếu người dùng chọn một dòng hợp lệ
                if (e.RowIndex >= 0)
                {
                    // Lấy mã đơn nhập từ cột đầu tiên (Giả sử là cột "MaDonNhap")
                    string maDonNhap = dataGV_DS_DonNhap.Rows[e.RowIndex].Cells["MaDonNhap"].Value.ToString();

                    // Gọi hàm từ BLL để lấy chi tiết đơn nhập
                    List<CT_DonNhap> chiTietList = bll_ttb.GetChiTietDonNhap(maDonNhap);

                    // Hiển thị dữ liệu lên dataGridView CT_DonNhap
                    data_GV_CT_DonNhap.DataSource = chiTietList;

                    // Tùy chỉnh hiển thị các cột
                    data_GV_CT_DonNhap.Columns["MaDonNhap"].HeaderText = "Mã Đơn Nhập";
                    data_GV_CT_DonNhap.Columns["MaThietBi"].HeaderText = "Mã Thiết Bị";
                    data_GV_CT_DonNhap.Columns["SoLuong"].HeaderText = "Số Lượng";
                    data_GV_CT_DonNhap.Columns["DonGia"].HeaderText = "Đơn Giá";
                    data_GV_CT_DonNhap.Columns["TrangThai"].HeaderText = "Trạng Thái";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết đơn nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Data_GV_CT_DonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        // Phương thức tải dữ liệu và hiển thị lên DataGridView
        private void LoadDonNhapData()
        {
            try
            {
                // Lấy dữ liệu từ BLL
                List<DonNhap_TTB> donNhapList = bll_ttb.GetAllActiveDonNhap();

                // Hiển thị dữ liệu lên DataGridView
                dataGV_DS_DonNhap.DataSource = donNhapList;

                // Tuỳ chỉnh hiển thị cột
                dataGV_DS_DonNhap.Columns["MaDonNhap"].HeaderText = "Mã Đơn Nhập";
                dataGV_DS_DonNhap.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
                dataGV_DS_DonNhap.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dataGV_DS_DonNhap.Columns["TrangThai"].HeaderText = "Trạng Thái";
                dataGV_DS_DonNhap.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
                dataGV_DS_DonNhap.Columns["MaNCC"].HeaderText = "Mã NCC";

                // Ẩn tất cả các cột khác
                foreach (DataGridViewColumn column in dataGV_DS_DonNhap.Columns)
                {
                    if (column.Name != "MaDonNhap" &&
                        column.Name != "NgayNhap" &&
                        column.Name != "TongTien" &&
                        column.Name != "TrangThai" &&
                        column.Name != "MaNhanVien" &&
                        column.Name != "MaNCC")
                    {
                        column.Visible = false; // Ẩn cột
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_HoaDonNhap_Click(object sender, EventArgs e)
        {
            // Đường dẫn tới mẫu Word
            string templatePath = @"D:\DACN\PhieuNhapThietBiHoaChat\PhieuXuatDonNhapTrangThietBi\HoaDonNhapTrangThietBi.docx";
            string outputPath = @"D:\DACN\PhieuNhapThietBiHoaChat\PhieuXuatDonNhapTrangThietBi\HoaDonNhapThietBi_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".docx";

            // Kiểm tra xem file mẫu có tồn tại không
            if (!File.Exists(templatePath))
            {
                MessageBox.Show("Không tìm thấy file mẫu tại: " + templatePath, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo ứng dụng Word và mở file mẫu
            Microsoft.Office.Interop.Word._Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(templatePath);

            try
            {
                // Lấy thông tin từ giao diện
                string tenNhaCungCap = cbo_TenNhaCungCap.Text;
                string emailNCC = txt_Email_NhaCungCap.Text;
                string soDienThoaiNCC = txt_SoDienThoai_NCC.Text;
                string diaChiNCC = $"{txt_Duong_Thon.Text}, {comboBoxXa.Text}, {comboBoxHuyen.Text}, {comboBoxTinhThanh.Text}";
                string hoVaTenNhanVien = "Lê Nhật Quyên"; // Có thể thay bằng thông tin thực tế từ tài khoản đăng nhập
                string chucVu = "Nhân Viên Quản Lý";
                string soQuyetDinh = "12345";
                string ngayLap = DateTime.Now.ToString("dd");
                string thangLap = DateTime.Now.ToString("MM");
                string namLap = DateTime.Now.ToString("yyyy");
                string tongTien = txt_tongTienNhap.Text;

                // Thay thế các placeholder trong tài liệu
                ReplacePlaceholder(doc, "«SoQuyetDinh»", soQuyetDinh);
                ReplacePlaceholder(doc, "«Ngay»", ngayLap);
                ReplacePlaceholder(doc, "«Thang»", thangLap);
                ReplacePlaceholder(doc, "«Nam»", namLap);
                ReplacePlaceholder(doc, "«TenNhaCungCap»", tenNhaCungCap);
                ReplacePlaceholder(doc, "«Email»", emailNCC);
                ReplacePlaceholder(doc, "«SoDienThoai»", soDienThoaiNCC);
                ReplacePlaceholder(doc, "«DiaChi»", diaChiNCC);
                ReplacePlaceholder(doc, "«HoVaTenNhanVien»", hoVaTenNhanVien);
                ReplacePlaceholder(doc, "«ChucVu»", chucVu);
                ReplacePlaceholder(doc, "«TongTien»", tongTien);

                // Tìm bảng trong Word và thay thế dữ liệu
                Microsoft.Office.Interop.Word.Range searchRange = doc.Content;
                searchRange.Find.ClearFormatting();
                // Thay đổi nội dung tìm kiếm để sử dụng giá trị Chức Vụ
                searchRange.Find.Text = "Bộ Phận : " + "Nhân Viên Quản Lý";

                if (searchRange.Find.Execute())
                {
                    // Di chuyển vị trí đến sau văn bản tìm được
                    Microsoft.Office.Interop.Word.Range tableRange = doc.Range(searchRange.End, doc.Content.End);
                    Microsoft.Office.Interop.Word.Table targetTable = null;

                    // Xác định bảng đầu tiên sau vị trí đã tìm
                    foreach (Microsoft.Office.Interop.Word.Table tbl in doc.Tables)
                    {
                        if (tbl.Range.Start >= tableRange.Start)
                        {
                            targetTable = tbl;
                            break;
                        }
                    }

                    if (targetTable == null)
                    {
                        MessageBox.Show("Không tìm thấy bảng phù hợp trong tài liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    // Xóa các dòng cũ trong bảng (trừ dòng tiêu đề nếu có)
                    while (targetTable.Rows.Count > 1)
                    {
                        targetTable.Rows[2].Delete();
                    }

                    // Thêm dữ liệu từ DataGridView vào bảng
                    for (int i = 0; i < dataGV_DS_Nhap_TTB.Rows.Count; i++)
                    {
                        DataGridViewRow row = dataGV_DS_Nhap_TTB.Rows[i];
                        if (row.IsNewRow) continue;

                        string stt = (i + 1).ToString();
                        string maThietBi = row.Cells["MaThietBi"].Value?.ToString() ?? "";
                        string tenThietBi = row.Cells["TenThietBi"].Value?.ToString() ?? "";
                        string soLuong = row.Cells["SoLuong"].Value?.ToString() ?? "";
                        string donGia = row.Cells["DonGia"].Value?.ToString() ?? "";

                        // Thêm dòng mới vào bảng Word
                        Microsoft.Office.Interop.Word.Row newRow = targetTable.Rows.Add();
                        newRow.Cells[1].Range.Text = stt;
                        newRow.Cells[2].Range.Text = maThietBi;
                        newRow.Cells[3].Range.Text = tenThietBi;
                        newRow.Cells[4].Range.Text = soLuong;
                        newRow.Cells[5].Range.Text = donGia;
                    }

                    // Lưu tài liệu
                    doc.SaveAs2(outputPath);
                    MessageBox.Show("Hóa đơn nhập thiết bị đã được lưu tại: " + outputPath, "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tạo hóa đơn nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng tài liệu và ứng dụng Word
                doc.Close(false);
                wordApp.Quit();

                // Giải phóng tài nguyên COM
                System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
            }
        }

        private void ReplacePlaceholder(Microsoft.Office.Interop.Word.Document doc, string placeholder, string value)
        {
            Microsoft.Office.Interop.Word.Find findObject = doc.Content.Find;
            findObject.ClearFormatting();
            findObject.Text = placeholder;
            findObject.Replacement.ClearFormatting();
            findObject.Replacement.Text = value;
            findObject.Execute(Replace: Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll);
        }


        private void Btn_LuuPhieuNhap_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng BLL
                BLL_NhapTrangThietBi bllNTTB = new BLL_NhapTrangThietBi();

                // Lấy thông tin từ các ô nhập liệu
                string maNCC = txt_MaNhaCungCap.Text.Trim();
                DateTime ngayNhap = dateTime_NgayNhap.Value;
                decimal tongTienNhap = decimal.Parse(txt_tongTienNhap.Text.Trim());
                string trangThai = "Hoạt Động";
                string maNhanVien = "NV001";

                // Kiểm tra danh sách nhập từ DataGridView
                if (dataGV_DS_Nhap_TTB.Rows.Count == 0)
                {
                    MessageBox.Show("Danh sách nhập trang thiết bị không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng DonNhap_TTB
                DonNhap_TTB donNhap = new DonNhap_TTB
                {
                    NgayNhap = ngayNhap,
                    TongTien = tongTienNhap,
                    TrangThai = trangThai,
                    MaNhanVien = maNhanVien,
                    MaNCC = maNCC
                };

                // Lấy danh sách chi tiết đơn nhập từ DataGridView
                List<CT_DonNhap> chiTietDonNhap = new List<CT_DonNhap>();

                foreach (DataGridViewRow row in dataGV_DS_Nhap_TTB.Rows)
                {
                    if (row.Cells["MaThietBi"].Value != null && row.Cells["SoLuong"].Value != null && row.Cells["DonGia"].Value != null)
                    {
                        CT_DonNhap chiTiet = new CT_DonNhap
                        {
                            MaThietBi = row.Cells["MaThietBi"].Value.ToString(),
                            SoLuong = int.Parse(row.Cells["SoLuong"].Value.ToString()),
                            DonGia = decimal.Parse(row.Cells["DonGia"].Value.ToString()),
                            TrangThai = "Đã nhập"
                        };
                        chiTietDonNhap.Add(chiTiet);
                    }
                }

                // Gọi phương thức thêm đơn nhập từ BLL
                bool result = bllNTTB.ThemDonNhapTTB(donNhap, chiTietDonNhap);

                if (result)
                {
                    MessageBox.Show("Lưu phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Reset hoặc cập nhật giao diện sau khi lưu thành công
                    txt_MaNhaCungCap.Clear();
                    txt_tongTienNhap.Clear();
                    dataGV_DS_Nhap_TTB.Rows.Clear();
                }
                else
                {
                    MessageBox.Show("Lưu phiếu nhập thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Btn_Them_DSNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Chọn file Excel để nhập"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                    using (var package = new ExcelPackage(fileInfo))
                    {
                        // Lấy worksheet đầu tiên trong file
                        var worksheet = package.Workbook.Worksheets[0];

                        // Xác định số lượng hàng và cột
                        var rowCount = worksheet.Dimension.End.Row;
                        var colCount = worksheet.Dimension.End.Column;

                        MessageBox.Show("Số lượng cột: " + colCount.ToString());
                        MessageBox.Show("Số lượng hàng: " + rowCount.ToString());

                        if (colCount != dataGV_DS_Nhap_TTB.Columns.Count)
                        {
                            MessageBox.Show("Số lượng cột trong file Excel không khớp với số cột trong DataGridView.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Xóa dữ liệu cũ trong DataGridView
                        dataGV_DS_Nhap_TTB.Rows.Clear();

                        // Đọc dữ liệu từ worksheet và thêm vào DataGridView
                        for (int row = 5; row <= rowCount; row++)
                        {
                            var dgvRow = new DataGridViewRow();
                            for (int col = 1; col <= colCount; col++)
                            {
                                string cellValue = worksheet.Cells[row, col].Text.Trim();
                                dgvRow.Cells.Add(new DataGridViewTextBoxCell { Value = cellValue });
                            }
                            dataGV_DS_Nhap_TTB.Rows.Add(dgvRow);
                        }

                        // Tính tổng tiền ở cột "Đơn giá"
                        decimal tongTienNhap = 0;
                        foreach (DataGridViewRow row in dataGV_DS_Nhap_TTB.Rows)
                        {
                            if (row.Cells["DonGia"] != null && decimal.TryParse(row.Cells["DonGia"].Value?.ToString(), out decimal donGia))
                            {
                                tongTienNhap += donGia;
                            }
                        }

                        // Hiển thị tổng tiền lên TextBox
                        txt_tongTienNhap.Text = tongTienNhap.ToString("N2");

                        MessageBox.Show("Dữ liệu đã được nhập thành công từ file Excel!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi nhập dữ liệu từ Excel: " + ex.Message);
                }
            }
        }



        private void SetupDataGridView_DS_Nhap_TTB()
        {
            // Đảm bảo xóa các cột cũ trong DataGridView nếu có
            dataGV_DS_Nhap_TTB.Columns.Clear();

            // Thêm cột vào DataGridView
            dataGV_DS_Nhap_TTB.Columns.Add("STT", "STT");
            dataGV_DS_Nhap_TTB.Columns.Add("MaThietBi", "Mã Thiết Bị");
            dataGV_DS_Nhap_TTB.Columns.Add("TenThietBi", "Tên Thiết Bị");
            dataGV_DS_Nhap_TTB.Columns.Add("SoLuong", "Số Lượng");
            dataGV_DS_Nhap_TTB.Columns.Add("DonGia", "Đơn Giá");
        }

        private void Cbo_TenNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu ComboBox không rỗng và có item được chọn
            if (cbo_TenNhaCungCap.SelectedItem != null)
            {
                // Lấy tên nhà cung cấp từ ComboBox
                string tenNCC = cbo_TenNhaCungCap.Text.Trim();
               // MessageBox.Show("Tên Nhà Cung Cấp: " + tenNCC);

                // Khởi tạo lớp BLL_NhaCungCap
                BLL_NhaCungCap bll_ncc = new BLL_NhaCungCap();

                // Gọi phương thức trong BLL để lấy thông tin nhà cung cấp theo tên
                var nhaCungCap = bll_ncc.GetNhaCungCapByName(tenNCC);

                // Kiểm tra nếu nhà cung cấp được tìm thấy
                if (nhaCungCap != null)
                {
                    // Cập nhật các TextBox và ComboBox với thông tin của nhà cung cấp
                    txt_MaNhaCungCap.Text = nhaCungCap.MaNCC;
                    txt_Email_NhaCungCap.Text = nhaCungCap.Email;
                    txt_SoDienThoai_NCC.Text = nhaCungCap.SoDienThoai;

                    // Kiểm tra nếu địa chỉ không rỗng và có ít nhất một phần tử
                    string[] diaChiParts = nhaCungCap.DiaChi?.Split(',');
                    if (diaChiParts != null && diaChiParts.Length >= 4)
                    {
                        txt_Duong_Thon.Text = diaChiParts[0].Trim();      // Đoạn đường/thôn
                        comboBoxXa.Text = diaChiParts[1].Trim();          // Phường/Xã
                        comboBoxHuyen.Text = diaChiParts[2].Trim();       // Quận/Huyện
                        comboBoxTinhThanh.Text = diaChiParts[3].Trim();   // Tỉnh/Thành phố
                    }
                    else
                    {
                        // Thông báo lỗi nếu địa chỉ không đầy đủ hoặc rỗng
                        MessageBox.Show("Địa chỉ không đầy đủ hoặc không đúng định dạng.");
                        txt_Duong_Thon.Clear();
                        comboBoxXa.SelectedIndex = -1;
                        comboBoxHuyen.SelectedIndex = -1;
                        comboBoxTinhThanh.SelectedIndex = -1;
                    }
                }
                else
                {
                    // Nếu không tìm thấy nhà cung cấp, hiển thị thông báo
                   // MessageBox.Show("Không tìm thấy thông tin nhà cung cấp.");
                }
            }
            else
            {
                // Nếu không có mục nào được chọn trong ComboBox, xóa dữ liệu TextBox và ComboBox
                txt_MaNhaCungCap.Clear();
                txt_Email_NhaCungCap.Clear();
                txt_SoDienThoai_NCC.Clear();
                txt_Duong_Thon.Clear();
                comboBoxXa.SelectedIndex = -1;
                comboBoxHuyen.SelectedIndex = -1;
                comboBoxTinhThanh.SelectedIndex = -1;
            }
        }



        private void LoadCombo_TenNhaCungCap()
        {
            try
            {
                // Khởi tạo BLL_NhaCungCap
                BLL_NhaCungCap bll_ncc = new BLL_NhaCungCap();

                // Lấy tất cả tên nhà cung cấp từ BLL
                List<NhaCungCap> danhSach_TenNCC = bll_ncc.GetAllNhaCungCapNames();

                // Gán danh sách vào ComboBox và thiết lập thuộc tính hiển thị
                cbo_TenNhaCungCap.DataSource = danhSach_TenNCC;
                cbo_TenNhaCungCap.DisplayMember = "TenNCC";  // Thuộc tính để hiển thị
                cbo_TenNhaCungCap.ValueMember = "MaNCC";     // Giá trị để lấy mã nhà cung cấp
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tải danh sách nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void ComboBoxHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHuyen.SelectedItem is ComboBoxItem selectedItem)
            {
                int districtId = (int)selectedItem.Value;
                await LoadXaAsync(districtId);
            }
        }

        private async void ComboBoxTinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTinhThanh.SelectedItem is ComboBoxItem selectedItem)
            {
                int provinceId = (int)selectedItem.Value;
                await LoadHuyenAsync(provinceId);
            }
        }

        private void DataGV_CT_TrangThietBi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra nếu người dùng nhấn vào một dòng hợp lệ (không phải header)
                if (e.RowIndex >= 0)
                {
                    // Sử dụng chỉ số cột thay vì tên cột
                    string maThietBi = dataGV_CT_TrangThietBi.Rows[e.RowIndex].Cells[0].Value.ToString(); // Cột 0 là MaThietBi
                    string maPhong = dataGV_CT_TrangThietBi.Rows[e.RowIndex].Cells[1].Value.ToString(); // Cột 1 là MaPhong

                    // Gọi BLL để lấy thông tin chi tiết về thiết bị theo Mã thiết bị và Mã phòng
                    PhieuKTTrangThietBi phieu = bll_ttb.GetCT_TrangThietBiByMaThietBiAndMaPhong(maThietBi, maPhong);

                    // Kiểm tra nếu có kết quả
                    if (phieu != null)
                    {
                        // Cập nhật thông tin vào các điều khiển (TextBox, ComboBox)
                        txt_MaTTB.Text = maThietBi;
                        cbo_MaPhong.SelectedItem = maPhong; // Cập nhật ComboBox mã phòng
                        cbo_Ten_TTB.SelectedItem = phieu.TenThietBi; // Cập nhật ComboBox tên thiết bị
                        txt_soluong.Text = phieu.SoLuong.ToString();
                        txt_TrangThai.Text = "Trạng thái chưa xác định"; // Cập nhật trạng thái nếu cần, có thể thay đổi sau
                    }
                    else
                    {
                        // Nếu không tìm thấy thông tin
                        MessageBox.Show("Không tìm thấy thông tin thiết bị.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Lỗi khi xử lý dữ liệu: " + ex.Message);
            }
        }



        private void Cbo_Ten_TTB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu có mục nào được chọn
            if (cbo_Ten_TTB.SelectedIndex != -1)
            {
                // Lấy tên trang thiết bị từ ComboBox
                string tenThietBi = cbo_Ten_TTB.SelectedItem.ToString();

                // Gọi phương thức BLL để lấy mã thiết bị
                string maThietBi = bll_ttb.GetMaThietBiByTen(tenThietBi);

                // Hiển thị mã thiết bị trong TextBox hoặc xử lý khác nếu cần
                if (!string.IsNullOrEmpty(maThietBi))
                {
                    txt_MaTTB.Text = maThietBi; // Hiển thị mã thiết bị trong TextBox
                }
                else
                {
                    txt_MaTTB.Text = "Không có mã thiết bị!"; // Nếu không tìm thấy
                }
            }
        }

        private void Cbo_MaPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (cbo_MaPhong.SelectedIndex != -1)
    {
        string maPhong = cbo_MaPhong.SelectedValue.ToString(); // Lấy mã phòng đã chọn
        string tenLoaiPhong = bll_ttb.GetTenLoaiPhong(maPhong); // Gọi BLL để lấy tên loại phòng

        if (!string.IsNullOrEmpty(tenLoaiPhong))
        {
            txt_LoaiPhong.Text = tenLoaiPhong; // Hiển thị tên loại phòng

            // Lấy danh sách trang thiết bị theo mã phòng (hoặc loại phòng)
            var trangThietBiList = bll_ttb.GetTrangThietBiByMaPhong(maPhong); // Gọi BLL để lấy danh sách trang thiết bị

            // Cập nhật ComboBox với danh sách trang thiết bị
            cbo_Ten_TTB.Items.Clear(); // Xóa tất cả các item cũ trong cbo_Ten_TTB

            if (trangThietBiList.Any()) // Kiểm tra nếu có trang thiết bị
            {
                foreach (var thietBi in trangThietBiList)
                {
                    cbo_Ten_TTB.Items.Add(thietBi); // Thêm từng trang thiết bị vào cbo_Ten_TTB
                }
            }
            else
            {
                cbo_Ten_TTB.Items.Add("Không có trang thiết bị cho loại phòng này"); // Nếu không có trang thiết bị
            }
        }
        else
        {
            txt_LoaiPhong.Text = "Không có thông tin loại phòng!"; // Nếu không tìm thấy tên loại phòng
            cbo_Ten_TTB.Items.Clear(); // Xóa tất cả các item cũ trong cbo_Ten_TTB
        }
    }
        }

        private void LoadMaPhongToComboBox()
        {
            // Lấy danh sách phòng từ BLL
            List<Phong> danhSachPhong = bll_ttb.GetAllMaPhong();

            // Gán danh sách mã phòng vào ComboBox
            cbo_MaPhong.DataSource = danhSachPhong;
            cbo_MaPhong.DisplayMember = "MaPhong"; // Hiển thị thuộc tính MaPhong trong ComboBox
            cbo_MaPhong.ValueMember = "MaPhong";   // Giá trị là thuộc tính MaPhong
        }
        private void DataGV_TrangThietBi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có click vào một hàng hợp lệ không
            if (e.RowIndex >= 0)
            {
                // Lấy mã thiết bị từ cột đầu tiên của hàng được chọn
                string maThietBi = dataGV_TrangThietBi.Rows[e.RowIndex].Cells[0].Value.ToString();

                // Gọi hàm BLL để lấy thông tin thiết bị theo mã
                TrangThietBi thietBi = bll_ttb.GetTrangThietBiById(maThietBi);

                if (thietBi != null)
                {
                    // Hiển thị thông tin thiết bị lên các TextBox
                    txt_Ma_TTB.Text = thietBi.MaThietBi;
                    txt_Ten_TTB.Text = thietBi.TenThietBi;
                    txt_trangthai_TTB.Text = thietBi.TrangThai;
                }
            }
        }

        private async void QuanLyTrangThietBi_Load(object sender, EventArgs e)
        {
            LoadDonNhapData();
            LoadDuLieuTrangThietBI();
            LoadMaPhongToComboBox();
            LoadDataCT_TrangThietBi();
            await LoadTinhThanhAsync();
            LoadCombo_TenNhaCungCap();
            SetupDataGridView_DS_Nhap_TTB();
        }
        private void LoadDuLieuTrangThietBI()
        {
            // Cấu hình các cột cho DataGridView
            dataGV_TrangThietBi.AutoGenerateColumns = false;
            dataGV_TrangThietBi.Columns.Clear();

            // Tạo các cột
            DataGridViewTextBoxColumn colMaThietBi = new DataGridViewTextBoxColumn();
            colMaThietBi.HeaderText = "Mã Thiết Bị";
            colMaThietBi.DataPropertyName = "MaThietBi"; // Tên thuộc tính trong lớp TrangThietBi
            dataGV_TrangThietBi.Columns.Add(colMaThietBi);

            DataGridViewTextBoxColumn colTenThietBi = new DataGridViewTextBoxColumn();
            colTenThietBi.HeaderText = "Tên Thiết Bị";
            colTenThietBi.DataPropertyName = "TenThietBi"; // Tên thuộc tính trong lớp TrangThietBi
            dataGV_TrangThietBi.Columns.Add(colTenThietBi);

            DataGridViewTextBoxColumn colTrangThai = new DataGridViewTextBoxColumn();
            colTrangThai.HeaderText = "Trạng Thái";
            colTrangThai.DataPropertyName = "TrangThai"; // Tên thuộc tính trong lớp TrangThietBi
            dataGV_TrangThietBi.Columns.Add(colTrangThai);

            // Lấy danh sách trang thiết bị từ BLL
            List<TrangThietBi> danhSachThietBi = bll_ttb.GetAllTrangThietBi();

            // Gán danh sách vào DataGridView
            dataGV_TrangThietBi.DataSource = danhSachThietBi;
        }
        private void LoadDataCT_TrangThietBi()
        {
            // Cấu hình các cột cho DataGridView
            dataGV_CT_TrangThietBi.AutoGenerateColumns = false;
            dataGV_CT_TrangThietBi.Columns.Clear();

            // Tạo các cột
            DataGridViewTextBoxColumn colMaThietBi = new DataGridViewTextBoxColumn();
            colMaThietBi.HeaderText = "Mã Thiết Bị";
            colMaThietBi.DataPropertyName = "MaThietBi"; // Tên thuộc tính trong lớp CT_TrangThietBi
            dataGV_CT_TrangThietBi.Columns.Add(colMaThietBi);

            DataGridViewTextBoxColumn colMaPhong = new DataGridViewTextBoxColumn();
            colMaPhong.HeaderText = "Mã Phòng";
            colMaPhong.DataPropertyName = "MaPhong"; // Tên thuộc tính trong lớp CT_TrangThietBi
            dataGV_CT_TrangThietBi.Columns.Add(colMaPhong);

            DataGridViewTextBoxColumn colSoLuong = new DataGridViewTextBoxColumn();
            colSoLuong.HeaderText = "Số Lượng";
            colSoLuong.DataPropertyName = "SoLuong"; // Tên thuộc tính trong lớp CT_TrangThietBi
            dataGV_CT_TrangThietBi.Columns.Add(colSoLuong);

            DataGridViewTextBoxColumn colTrangThai = new DataGridViewTextBoxColumn();
            colTrangThai.HeaderText = "Trạng Thái";
            colTrangThai.DataPropertyName = "TrangThai"; // Tên thuộc tính trong lớp CT_TrangThietBi
            dataGV_CT_TrangThietBi.Columns.Add(colTrangThai);

            // Lấy danh sách CT_TrangThietBi từ BLL
            List<CT_TrangThietBi> danhSachCT_TrangThietBi = bll_ttb.GetAllCT_TrangThietBi();

            // Gán danh sách vào DataGridView
            dataGV_CT_TrangThietBi.DataSource = danhSachCT_TrangThietBi;
        }

        private void txt_maSinhVien_TextChanged_2(object sender, EventArgs e)
        {

        }

        private async Task LoadTinhThanhAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = "https://provinces.open-api.vn/api/p/";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<TinhThanh> data = JsonConvert.DeserializeObject<List<TinhThanh>>(responseBody);

                    comboBoxTinhThanh.Items.Clear();
                    foreach (var item in data)
                    {
                        comboBoxTinhThanh.Items.Add(new ComboBoxItem { Text = item.Name, Value = item.Code });
                    }

                    comboBoxTinhThanh.DisplayMember = "Text";
                    comboBoxTinhThanh.ValueMember = "Value";
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private async Task LoadHuyenAsync(int provinceId)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = $"https://provinces.open-api.vn/api/p/{provinceId}?depth=2";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    var provinceData = JsonConvert.DeserializeObject<TinhThanhChiTiet>(responseBody);

                    comboBoxHuyen.Items.Clear();
                    foreach (var item in provinceData.Districts)
                    {
                        comboBoxHuyen.Items.Add(new ComboBoxItem { Text = item.Name, Value = item.Code });
                    }

                    comboBoxHuyen.DisplayMember = "Text";
                    comboBoxHuyen.ValueMember = "Value";
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private async Task LoadXaAsync(int districtId)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = $"https://provinces.open-api.vn/api/d/{districtId}?depth=2";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    var districtData = JsonConvert.DeserializeObject<HuyenChiTiet>(responseBody);

                    comboBoxXa.Items.Clear();
                    foreach (var item in districtData.Wards)
                    {
                        comboBoxXa.Items.Add(new ComboBoxItem { Text = item.Name, Value = item.Code });
                    }

                    comboBoxXa.DisplayMember = "Text";
                    comboBoxXa.ValueMember = "Value";
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}
