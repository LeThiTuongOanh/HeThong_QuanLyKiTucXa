using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Control;
using DTO;

namespace GUI
{
    public partial class ThongTinSinhVien : Form
    {
        BLL_QL_SinhVien bllSinhVien=new BLL_QL_SinhVien();
        private PictureBox selectedPictureBox;
        private string hinhNhanDienPath;
        private string hinhCCCDTruocPath;
        private string hinhCCCDSauPath;
        //Cờ thông báo lỗi
        private bool isImageErrorShown = false;

        public ThongTinSinhVien()
        {
            InitializeComponent();
            this.Load += ThongTinSinhVien_Load;

            datagridview_SinhVien.CellClick += Datagridview_SinhVien_CellClick;
            btn_CapNhatSinhVien.Click += Btn_CapNhatSinhVien_Click;

            pictureBox1.Click += PictureBox_Click;
            Picture_CCCDTruoc.Click += PictureBox_Click;
            picture_CCCDSau.Click += PictureBox_Click;

            btn_Chonfile.Click += Btn_Chonfile_Click;
            btn_TimKiem.Click += Btn_TimKiem_Click;
        }

        private void Btn_TimKiem_Click(object sender, EventArgs e)
        {
           string maSV=txt_TimMSSV.Text.Trim();
            if(string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Vui lòng nhập mã số sinh viên cần tìm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }    
            var sinhvien=bllSinhVien.GetSinhVienByMa(maSV);


            if (sinhvien != null)
            {
                datagridview_SinhVien.DataSource = new List<SinhVien> { sinhvien };
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên với mã số này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                datagridview_SinhVien.DataSource = bllSinhVien.GetAllSinhViens();

            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
           selectedPictureBox=sender as PictureBox;//Luu pictureBox đang chọn
        }

       
        private void Btn_Chonfile_Click(object sender, EventArgs e)
        {

            if (selectedPictureBox == null)
            {
                MessageBox.Show("Vui lòng chọn một khung hình trước khi chọn file.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Chọn hình ảnh";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    Bitmap resizedImage = new Bitmap(Image.FromFile(selectedImagePath), new Size(168, 209));
                    selectedPictureBox.Image = resizedImage;

                    // Lưu đường dẫn vào đúng biến
                    if (selectedPictureBox == pictureBox1)
                        hinhNhanDienPath = selectedImagePath;
                    else if (selectedPictureBox == Picture_CCCDTruoc)
                        hinhCCCDTruocPath = selectedImagePath;
                    else if (selectedPictureBox == picture_CCCDSau)
                        hinhCCCDSauPath = selectedImagePath;
                }
            }
        }

        private void Btn_CapNhatSinhVien_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem mã sinh viên có được nhập không
            if (string.IsNullOrWhiteSpace(txt_MaSoSinhVien.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime ngaySinh =picker_NgaySinh.Value;
            int tuoi= DateTime.Now.Year- ngaySinh.Year;
            if (ngaySinh > DateTime.Now.AddYears(tuoi)) tuoi--; // Điều chỉnh tuổi nếu chưa đến sinh nhật năm nay
            if (tuoi < 18)
            {
                MessageBox.Show("Sinh viên phải từ 18 tuổi trở lên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Tạo đối tượng SinhVien mới
            var sinhVien = new SinhVien
            {
                MaSinhVien = txt_MaSoSinhVien.Text,
                HoTen = txt_HoTen.Text,
                CCCD = txt_CCCD.Text,
                SDT = txt_SDT.Text, // Số điện thoại
                NgaySinh = picker_NgaySinh.Value,
                GioiTinh = txt_GioiTinh.Text,
                Email = txt_Email.Text, // Cập nhật trường email
                HoKhauThuongTru = txt_HoKhauThuongTru.Text,
                NoiSinh = txt_NoiSinh.Text,
                GhiChu = txt_GhiChu.Text,
                TruongPhong = check_truongPhong.Checked, // Kiểu boolean
                HinhNhanDien = string.IsNullOrEmpty(hinhNhanDienPath) ? "user.png" : Path.GetFileName(hinhNhanDienPath), // Sử dụng hình ảnh đã chọn
                HinhCCCDTruoc = string.IsNullOrEmpty(hinhCCCDTruocPath) ? txt_CCCCTruoc.Text : Path.GetFileName(hinhCCCDTruocPath),
                HinhCCCDSau = string.IsNullOrEmpty(hinhCCCDSauPath) ? txt_CCCDSau.Text : Path.GetFileName(hinhCCCDSauPath)

            };

            // Gọi phương thức cập nhật từ BLL
            var result = bllSinhVien.UpdateSinhVien(sinhVien);

            if (result)
            {
                MessageBox.Show("Cập nhật thông tin sinh viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại DataGridView
                datagridview_SinhVien.DataSource = bllSinhVien.GetAllSinhViens();
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin sinh viên không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Datagridview_SinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có click vào hàng hợp lệ không
            if (e.RowIndex >= 0) // Kiểm tra hàng có hợp lệ không
            {
                // Lấy thông tin sinh viên từ hàng đã chọn
                var sinhVien = (SinhVien)datagridview_SinhVien.Rows[e.RowIndex].DataBoundItem;

              
                txt_MaSoSinhVien.Text = sinhVien.MaSinhVien;
                txt_HoTen.Text = sinhVien.HoTen;
                txt_CCCD.Text = sinhVien.CCCD;
                txt_SDT.Text = sinhVien.SDT; 
                picker_NgaySinh.Value = sinhVien.NgaySinh; 
                txt_GioiTinh.Text = sinhVien.GioiTinh;
                txt_Email.Text = sinhVien.Email;
                txt_HoKhauThuongTru.Text = sinhVien.HoKhauThuongTru;
                txt_NoiSinh.Text = sinhVien.NoiSinh;
                txt_GhiChu.Text = sinhVien.GhiChu;
                txt_CCCDSau.Text = sinhVien.HinhCCCDSau;
                txt_CCCCTruoc.Text = sinhVien.HinhCCCDTruoc;
                check_truongPhong.Checked = Convert.ToBoolean(sinhVien.TruongPhong);// Nếu trường là boolean


                LoadImageToPictureBox(sinhVien.HinhNhanDien, pictureBox1);
                LoadImageToPictureBox(sinhVien.HinhCCCDTruoc, Picture_CCCDTruoc);
                LoadImageToPictureBox(sinhVien.HinhCCCDSau, picture_CCCDSau);


            //    // Cập nhật hình ảnh nhận diện
            //    if (!string.IsNullOrEmpty(sinhVien.HinhNhanDien))
            //    {
            //        string imagePath = Path.Combine("D:\\DoAnChuyenNganh\\QLKTX\\DoAn_QuanLyKyTucXa\\DoAn_QL_KTX\\GUI\\Resources", sinhVien.HinhNhanDien);
            //        if (File.Exists(imagePath)) // Kiểm tra xem file có tồn tại không
            //        {
            //            // pictureBox1.Image = Image.FromFile(imagePath); // Cập nhật hình từ HinhNhanDien
            //            // Tải hình ảnh từ file và hiển thị trong PictureBox
            //            using (Image img = Image.FromFile(imagePath))
            //            {
            //                // Tạo một Bitmap mới với kích thước 168x209 và vẽ hình ảnh vào Bitmap
            //                Bitmap resizedImage = new Bitmap(img, new Size(168, 209));
            //                pictureBox1.Image = resizedImage; // Cập nhật hình trong PictureBox
            //            }
            //        }
            //        else
            //        {
            //            pictureBox1.Image = null; // Nếu không tìm thấy hình, đặt hình ảnh là null
            //            MessageBox.Show("Hình ảnh không tồn tại.");
            //        }
            //    }
            //    else
            //    {
            //        pictureBox1.Image = null; // Nếu không có đường dẫn hình ảnh, đặt hình ảnh là null
            //    }
               
            //
            }
        }
     

        private void LoadImageToPictureBox(string imageName, PictureBox pictureBox)
        {
            if (string.IsNullOrEmpty(imageName))
            {
                if (!isImageErrorShown)
                {
                    MessageBox.Show("Đường dẫn hình ảnh không hợp lệ.");
                    isImageErrorShown = true; // Đánh dấu là đã thông báo lỗi
                }
                return;
            }

            string imagePath = Path.Combine("D:\\DoAnChuyenNganh\\QLKTX\\DoAn_QuanLyKyTucXa\\DoAn_QL_KTX\\GUI\\Resources", imageName);
            //  string imagePath = Path.Combine("GUI", "Resources", imageName);
            // string imagePath = Path.Combine(Application.StartupPath, "GUI", "Resources", imageName);
            
            try
            {
                if (File.Exists(imagePath))
                {
                    Bitmap resizedImage = new Bitmap(Image.FromFile(imagePath), new Size(168, 209));
                    pictureBox.Image = resizedImage;
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    isImageErrorShown = false; // Reset lại flag nếu hình ảnh hợp lệ

                }
                else
                {
                    pictureBox.Image = null;
                    if (!isImageErrorShown)
                    {
                        MessageBox.Show("Hình ảnh không tồn tại.");
                        isImageErrorShown = true; // Đánh dấu là đã thông báo lỗi
                    }
                }
            }
            catch (Exception ex)
            {
                if (!isImageErrorShown)
                {
                    MessageBox.Show($"Lỗi khi đọc hình ảnh: {ex.Message}");
                    isImageErrorShown = true; // Đánh dấu là đã thông báo lỗi
                }
            }

        }


        private void ThongTinSinhVien_Load(object sender, EventArgs e)
        {
            datagridview_SinhVien.DataSource=bllSinhVien.GetAllSinhViens();
          
            datagridview_SinhVien.Columns["MaSinhVien"].HeaderText = "Mã sinh viên";
            datagridview_SinhVien.Columns["HoTen"].HeaderText = "Họ tên";
            datagridview_SinhVien.Columns["CCCD"].HeaderText = "CCCD";
            datagridview_SinhVien.Columns["Email"].HeaderText = "Email";
            datagridview_SinhVien.Columns["SDT"].HeaderText = "Số điện thoại";
            datagridview_SinhVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            datagridview_SinhVien.Columns["GioiTinh"].HeaderText = "Giới tính";
            datagridview_SinhVien.Columns["HoKhauThuongTru"].HeaderText = "Hộ khẩu thường trú";
            datagridview_SinhVien.Columns["NoiSinh"].HeaderText = "Nơi sinh";
            datagridview_SinhVien.Columns["GhiChu"].HeaderText = "Ghi chú";
            datagridview_SinhVien.Columns["TruongPhong"].HeaderText = "Trưởng phòng";
            datagridview_SinhVien.Columns["HinhCCCDTruoc"].HeaderText = "Hình CCCD trước";
            datagridview_SinhVien.Columns["HinhCCCDSau"].HeaderText = "Hình CCCD sau"; 
            datagridview_SinhVien.Columns["HinhNhanDien"].HeaderText = "Hình nhận diện";

        }
       
    }
}
