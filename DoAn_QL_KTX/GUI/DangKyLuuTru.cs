using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control;
using BLL;
using DTO;
using System.IO;
namespace GUI
{
    public partial class DangKyLuuTru : Form
    {
        QL_LuuTru bllQuanLyLuuTru= new QL_LuuTru();
        private PictureBox selectedPictureBox;

        private FormMain _mainForm; // Biến để lưu tham chiếu tới FormMain

        public DangKyLuuTru(FormMain mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm; // Lưu tham chiếu
            btn_daCoHoSo.Click += Btn_daCoHoSo_Click;
            LoadCombo_Phong();
            LoadCombo_Giuong();
            Load_LoaiPhong();
            btn_DangKi.Click += Btn_DangKi_Click;
            btn_ChonFile.Click += Btn_ChonFileNhanDien_Click;
            //     btn_ChonFileCCCDTruoc.Click += Btn_ChonFileCCCDTruoc_Click;
            //    btn_ChonFileCCCDSau.Click += Btn_ChonFileCCCDSau_Click;

            btn_ChonFile.Click += Btn_ChonFile_Click;

            picture_CCCDSau.Click += Picture_Click;
            picture_CCCDTruoc.Click += Picture_Click;
            picture_HinhDaiDien.Click += Picture_Click;
        }

        private void Btn_ChonFile_Click(object sender, EventArgs e)
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
                    if (selectedPictureBox == picture_HinhDaiDien)
                        hinhNhanDienPath = selectedImagePath;
                    else if (selectedPictureBox == picture_CCCDTruoc)
                        hinhCCCDTruocPath = selectedImagePath;
                    else if (selectedPictureBox == picture_CCCDSau)
                        hinhCCCDSauPath = selectedImagePath;
                }
            }
        }

        private void Picture_Click(object sender, EventArgs e)
        {
            selectedPictureBox = sender as PictureBox;//Luu pictureBox đang chọn
        }

        private string hinhNhanDienPath;
        private string hinhCCCDTruocPath; 
        private string hinhCCCDSauPath;

        private void Btn_ChonFileCCCDSau_Click(object sender, EventArgs e)
        {
            //using (OpenFileDialog openFileDialog = new OpenFileDialog())
            //{
            //    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            //    openFileDialog.Title = "Chọn hình ảnh nhận diện";

            //    if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        // Lưu đường dẫn hình ảnh đã chọn
            //        hinhCCCDSauPath = openFileDialog.FileName;

            //        // Tạo một hình ảnh mới từ đường dẫn đã chọn
            //        using (Image img = Image.FromFile(hinhNhanDienPath))
            //        {
            //            // Tạo một Bitmap mới với kích thước 168x209 và vẽ hình ảnh vào Bitmap
            //            Bitmap resizedImage = new Bitmap(img, new Size(115, 66));
            //            picture_CCCDSau.Image = resizedImage; // Cập nhật hình trong PictureBox
            //        }
            //    }
            //}
            
        }

        private void Btn_ChonFileCCCDTruoc_Click(object sender, EventArgs e)
        {
            //using (OpenFileDialog openFileDialog = new OpenFileDialog())
            //{
            //    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            //    openFileDialog.Title = "Chọn hình ảnh nhận diện";

            //    if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        // Lưu đường dẫn hình ảnh đã chọn
            //        CCCDTruocPath = openFileDialog.FileName;

            //        // Tạo một hình ảnh mới từ đường dẫn đã chọn
            //        using (Image img = Image.FromFile(hinhNhanDienPath))
            //        {
            //            // Tạo một Bitmap mới với kích thước 168x209 và vẽ hình ảnh vào Bitmap
            //            Bitmap resizedImage = new Bitmap(img, new Size(115, 66));
            //            picture_CCCDTruoc.Image = resizedImage; // Cập nhật hình trong PictureBox
            //        }
            //    }
            //}
        }

        private void Btn_ChonFileNhanDien_Click(object sender, EventArgs e)
        {
            //using (OpenFileDialog openFileDialog = new OpenFileDialog())
            //{
            //    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            //    openFileDialog.Title = "Chọn hình ảnh nhận diện";

            //    if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        // Lưu đường dẫn hình ảnh đã chọn
            //        hinhNhanDienPath = openFileDialog.FileName;

            //        // Tạo một hình ảnh mới từ đường dẫn đã chọn
            //        using (Image img = Image.FromFile(hinhNhanDienPath))
            //        {
            //            // Tạo một Bitmap mới với kích thước 168x209 và vẽ hình ảnh vào Bitmap
            //            Bitmap resizedImage = new Bitmap(img, new Size(115, 66));
            //            picture_HinhDaiDien.Image = resizedImage; // Cập nhật hình trong PictureBox
            //        }
            //    }
            //}
        }

        private void Btn_DangKi_Click(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien();
            {
                sv.MaSinhVien = txt_MaSoSV.Text;
                sv.HoTen=txt_HoVaTen.Text;
                sv.TruongPhong = checkbox_TruongPhong.Checked;
                sv.NgaySinh = picker_NgaySinh.Value;
                sv.GioiTinh = rdo_nam.Checked ? "Nam" : "Nu";
                sv.NoiSinh=txt_NoiSinh.Text;
                sv.HoKhauThuongTru = txt_HoKhauThuongTru.Text;
                sv.Email=txt_Email.Text;
                sv.CCCD = txt_CCCD.Text;
                sv.GhiChu= txt_GhiChu.Text;
                sv.HinhNhanDien = string.IsNullOrEmpty(hinhNhanDienPath) ? "user.png" : Path.GetFileName(hinhNhanDienPath); // Sử dụng hình ảnh đã chọn
                sv.HinhCCCDTruoc = string.IsNullOrEmpty(hinhCCCDTruocPath) ? "" : Path.GetFileName(hinhCCCDTruocPath);
                sv.HinhCCCDSau = string.IsNullOrEmpty(hinhCCCDSauPath) ? "" : Path.GetFileName(hinhCCCDSauPath);
            }

            DangKyPhong dkphong= new DangKyPhong();
            {
                dkphong.MaDangKyPhong = int.Parse(txt_MaPhieu.Text);
                dkphong.MaSinhVien = sv.MaSinhVien;
                dkphong.MaPhong = cbo_phong.SelectedValue.ToString();
                dkphong.NgayDK = picker_NgayDK.Value;
                dkphong.NgayBD = picker_NgayVao.Value;
                dkphong.NgayKT = picker_NgayRa.Value;
                dkphong.Giuong = cbo_giuong.SelectedIndex + 1;
                dkphong.Tang = int.Parse(cbo_LoaiPhong.SelectedValue.ToString());
            }

            bool result = bllQuanLyLuuTru.ThemDangKyPhong(dkphong, sv);

            if (result)
            {
                MessageBox.Show("Đăng ký lưu trú thành công!");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi đăng ký lưu trú.");
            }
        }

        private void Btn_daCoHoSo_Click(object sender, EventArgs e)
        {
            _mainForm.OpenChildForm(new ThongTinLuuTru()); // Gọi OpenChildForm để mở ThongTinLuuTru
        }

        public void LoadCombo_Phong()
        {
            cbo_phong.DataSource = bllQuanLyLuuTru.GetPhong();
            cbo_phong.ValueMember= "MaPhong";
            cbo_phong.DisplayMember= "TenPhong";
        }
        public void LoadCombo_Giuong()
        {
            // Tạo danh sách các giường từ 0 đến 10
            List<int> giuongList = Enumerable.Range(1, 10).ToList(); // Tạo danh sách từ 0 đến 10

            // Gán danh sách cho combobox
           cbo_giuong.DataSource = giuongList;
        }

        public void Load_LoaiPhong()
        {
            cbo_LoaiPhong.DataSource = bllQuanLyLuuTru.GetLoais();
            cbo_LoaiPhong.ValueMember = "MaLoaiPhong";
            cbo_LoaiPhong.DisplayMember = "TenLoaiPhong";
        }

    }
}
