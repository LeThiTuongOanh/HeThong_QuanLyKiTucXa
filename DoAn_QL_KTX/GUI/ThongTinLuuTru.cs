using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
namespace GUI
{
    public partial class ThongTinLuuTru : Form
    {
        BLL_QL_LuuTru xuly = new BLL_QL_LuuTru();

        public ThongTinLuuTru()
        {
            InitializeComponent();

            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
           dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
         //   dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            this.Load += ThongTinLuuTru_Load;
            Load_ComboMaPhong();
            btn_Loc.Click += Btn_Loc_Click;
            btn_TimKiem.Click += Btn_TimKiem_Click;
            //    cbo_maPhong.SelectedIndexChanged += Cbo_maPhong_SelectedIndexChanged;
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Btn_TimKiem_Click(object sender, EventArgs e)
        {
            string maSV = txt_TimKiemTheo.Text.Trim();
            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Vui lòng nhập mã số sinh viên cần tìm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var sinhvien = xuly.GetTheoMaSV(maSV);


            if (sinhvien != null)
            {
                dataGridView1.DataSource = new List<DangKyPhong> { sinhvien };
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên với mã số này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = xuly.GetDangKyPhong();

            }
        }

        private void Cbo_maPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_maPhong.SelectedValue != null)
            {
                string selectedMaPhong = cbo_maPhong.SelectedValue.ToString();

                // Gọi phương thức lấy dữ liệu theo mã phòng đã chọn và hiển thị trong DataGridView
                dataGridView1.DataSource = xuly.GetDangKyPhongTheoMaPhong(selectedMaPhong);
            }
        }

        private void Btn_Loc_Click(object sender, EventArgs e)
        {
            if (cbo_maPhong.SelectedValue != null)
            {
                string selectedMaPhong = cbo_maPhong.SelectedValue.ToString();

                // Lấy dữ liệu theo mã phòng đã chọn và hiển thị trong DataGridView
                dataGridView1.DataSource = xuly.GetDangKyPhongTheoMaPhong(selectedMaPhong);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mã phòng để lọc.");
            }
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells["MaDangKyPhong"].Value != null)
            {
                int maDangKyPhong = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["MaDangKyPhong"].Value.ToString());
                string duLieuMoi = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                if (string.IsNullOrEmpty(duLieuMoi))
                {
                    MessageBox.Show("Dữ liệu không thể để trống.");
                    return;
                }

                bool isValid = true;
                DateTime? ngayDK = (DateTime?)dataGridView1.Rows[e.RowIndex].Cells["NgayDK"].Value;
                DateTime? ngayBD = (DateTime?)dataGridView1.Rows[e.RowIndex].Cells["NgayBD"].Value;
                DateTime? ngayKT = (DateTime?)dataGridView1.Rows[e.RowIndex].Cells["NgayKT"].Value;

                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

                switch (columnName)
                {
                    case "NgayDK": // Ngày đăng ký
                        if (DateTime.TryParse(duLieuMoi, out DateTime ngayDangKy))
                        {
                            if (ngayBD.HasValue && ngayDangKy >= ngayBD.Value)
                            {
                                isValid = false;
                                MessageBox.Show("Ngày đăng ký phải trước ngày bắt đầu ở.");
                            }
                        }
                        else
                        {
                            isValid = false;
                            MessageBox.Show("Ngày đăng ký không hợp lệ.");
                        }
                        break;

                    case "NgayBD": // Ngày bắt đầu
                        if (DateTime.TryParse(duLieuMoi, out DateTime ngayBatDau))
                        {
                            if ((ngayDK.HasValue && ngayBatDau <= ngayDK.Value) ||
                                (ngayKT.HasValue && ngayBatDau >= ngayKT.Value))
                            {
                                isValid = false;
                                MessageBox.Show("Ngày bắt đầu phải sau ngày đăng ký và trước ngày kết thúc.");
                            }
                        }
                        else
                        {
                            isValid = false;
                            MessageBox.Show("Ngày bắt đầu không hợp lệ.");
                        }
                        break;

                    case "NgayKT": // Ngày kết thúc
                        if (DateTime.TryParse(duLieuMoi, out DateTime ngayKetThuc))
                        {
                            if (ngayBD.HasValue && ngayKetThuc <= ngayBD.Value)
                            {
                                isValid = false;
                                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu.");
                            }
                        }
                        else
                        {
                            isValid = false;
                            MessageBox.Show("Ngày kết thúc không hợp lệ.");
                        }
                        break;

                    case "Giuong": // Giường
                        if (!int.TryParse(duLieuMoi, out _))
                        {
                            isValid = false;
                            MessageBox.Show("Giường phải là số nguyên hợp lệ.");
                        }
                        break;

                    case "Tang": // Tầng
                        if (!int.TryParse(duLieuMoi, out _))
                        {
                            isValid = false;
                            MessageBox.Show("Tầng phải là số nguyên hợp lệ.");
                        }
                        break;

                    default:
                        break;
                }

                if (isValid)
                {
                    bool updateSuccess = xuly.SuaPhieuDangKyPhong(maDangKyPhong, columnName, duLieuMoi);
                    MessageBox.Show(updateSuccess ? "Cập nhật thành công!" : "Cập nhật thất bại. Vui lòng thử lại.");
                }
            }
            else
            {
                MessageBox.Show("Mã ĐK phòng không hợp lệ.");
            }
        }


        private void ThongTinLuuTru_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = xuly.GetDangKyPhong();

            // Đặt tên hiển thị cho các cột và thiết lập ReadOnly cho các cột không được phép chỉnh sửa
            dataGridView1.Columns["MaDangKyPhong"].HeaderText = "Mã ĐK phòng";
            dataGridView1.Columns["MaDangKyPhong"].ReadOnly = true;
            dataGridView1.Columns["MaPhong"].HeaderText = "Mã phòng";
            dataGridView1.Columns["MaPhong"].ReadOnly = true;
            dataGridView1.Columns["MaSinhVien"].HeaderText = "Mã SV";
            dataGridView1.Columns["MaSinhVien"].ReadOnly = true;
            dataGridView1.Columns["NgayDK"].HeaderText = "Ngày ĐK";
            dataGridView1.Columns["NgayBD"].HeaderText = "Ngày BĐ ở";
            dataGridView1.Columns["NgayKT"].HeaderText = "Ngày KT ở";
            dataGridView1.Columns["Giuong"].HeaderText = "Giường";
            dataGridView1.Columns["Tang"].HeaderText = "Tầng";
            dataGridView1.Columns["NguyenVong1"].Visible = false;
            dataGridView1.Columns["NguyenVong2"].Visible = false;
            dataGridView1.Columns["TrangThai"].Visible = false;
            dataGridView1.Columns["Phong"].Visible = false;
            dataGridView1.Columns["SinhVien"].Visible = false;
            dataGridView1.Columns["HinhNhanDien"].Visible = false;

            // Thêm cột "Sửa" nếu chưa tồn tại
            if (!dataGridView1.Columns.Contains("btnEdit"))
            {
                DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Sửa",
                    Name = "btnEdit",
                    FlatStyle = FlatStyle.Flat,
                    UseColumnTextForButtonValue = true,
                    Text = "✏️"
                };
                dataGridView1.Columns.Add(editColumn);
            }

            // Thêm cột "Xóa" nếu chưa tồn tại
            if (!dataGridView1.Columns.Contains("btnDelete"))
            {
                DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Xóa",
                    Name = "btnDelete",
                    FlatStyle = FlatStyle.Flat,
                    UseColumnTextForButtonValue = true,
                    Text = "🗑️"
                };
                dataGridView1.Columns.Add(deleteColumn);
            }

            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                if (e.ColumnIndex == dataGridView1.Columns["btnEdit"].Index)
                {
                    int maDangKyPhong = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["MaDangKyPhong"].Value.ToString());
                    MessageBox.Show("Sửa thông tin cho Mã ĐK phòng: " + maDangKyPhong);
                }
                else if (e.ColumnIndex == dataGridView1.Columns["btnDelete"].Index)
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int maDKPhong = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["MaDangKyPhong"].Value.ToString());
                        bool deleteSuccess = xuly.XoaPhieuDangKyPhong(maDKPhong);
                        if (deleteSuccess)
                        {
                            MessageBox.Show("Xóa thành công!");
                            dataGridView1.DataSource = xuly.GetDangKyPhong();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại. Vui lòng thử lại.");
                        }
                    }
                }
            }
        }


        private void ThongTinLuuTru_Load_1(object sender, EventArgs e)
        {

        }

        private void Load_ComboMaPhong()
        {
            cbo_maPhong.DataSource=xuly.GetDangKyPhong();
            cbo_maPhong.ValueMember = "MaPhong";
            cbo_maPhong.DisplayMember= "MaPhong";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
