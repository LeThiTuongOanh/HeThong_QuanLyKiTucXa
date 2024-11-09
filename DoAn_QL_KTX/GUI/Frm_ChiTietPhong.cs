    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using DTO;
    using BLL;
    using System.Security.Cryptography;
    using System.IO;

    namespace GUI
    {
        public partial class Frm_ChiTietPhong : Form
        {
            public string maPhong;
            BLL_QL_LuuTru bll_luuTru= new BLL_QL_LuuTru();


            public Frm_ChiTietPhong()
            {
                InitializeComponent();
          

            }
            public Frm_ChiTietPhong(string maPhong) : this() // Gọi constructor mặc định
            {
                this.maPhong = maPhong; // Lưu trữ maPhong
                LoadThongTinSinhVien();
            }

            public void LoadThongTinSinhVien()
            {
                List<DangKyPhong> ds = bll_luuTru.LayThongTinSinhVien(maPhong);

                foreach (var sinhVien in ds)
                {
                    // Tạo một panel nhỏ để chứa cả PictureBox và Label cho mỗi sinh viên
                    Panel panelSinhVien = new Panel
                    {
                        Size = new Size(120, 150), // Kích thước của mỗi panel sinh viên
                        Margin = new Padding(10)   // Khoảng cách giữa các panel
                    };

                    // Tạo PictureBox để hiển thị hình ảnh của sinh viên
                    PictureBox picBox = new PictureBox
                    {
                        Size = new Size(100, 100), // Kích thước của hình ảnh
                   //     SizeMode = PictureBoxSizeMode.StretchImage, // Chế độ hiển thị hình ảnh
                        SizeMode = PictureBoxSizeMode.Zoom,
                        ImageLocation = sinhVien.HinhNhanDien // Đường dẫn ảnh
                    };

                    // Kiểm tra nếu đường dẫn ảnh không rỗng
                    if (!string.IsNullOrEmpty(sinhVien.HinhNhanDien))
                    {
                        try
                        {
                            // Xử lý đường dẫn để lấy hình ảnh
                          //  string imagePath = Path.Combine(Application.StartupPath, "GUI", "Resources", sinhVien.HinhNhanDien);
                            string imagePath = Path.Combine("D:\\DoAnChuyenNganh\\QLKTX\\DoAn_QuanLyKyTucXa\\DoAn_QL_KTX\\GUI\\Resources", sinhVien.HinhNhanDien);
                            // Kiểm tra xem file có tồn tại không
                            if (File.Exists(imagePath))
                            {
                                picBox.Image = Image.FromFile(imagePath); // Tải ảnh từ đường dẫn
                            }
                            else
                            {
                                // Nếu không tìm thấy ảnh, đặt ảnh mặc định
                                picBox.Image = Properties.Resources.user; // Ảnh mặc định
                            }
                        }
                        catch
                        {
                            // Xử lý nếu có lỗi khi tải ảnh
                            picBox.Image = Properties.Resources.user; // Ảnh mặc định
                        }
                    }
                    else
                    {
                        // Nếu không có đường dẫn ảnh, sử dụng ảnh mặc định
                        picBox.Image = Properties.Resources.user;
                    }

                    // Tạo Label để hiển thị mã sinh viên bên dưới hình ảnh
                    Label lblMaSinhVien = new Label
                    {
                        Text = sinhVien.MaSinhVien,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Bottom,
                        Height = 20
                    };

                    // Thêm PictureBox và Label vào panel của sinh viên
                    panelSinhVien.Controls.Add(picBox);
                    panelSinhVien.Controls.Add(lblMaSinhVien);

                    // Thêm panel của sinh viên vào FlowLayoutPanel chính
                    flowLayoutPanel1.Controls.Add(panelSinhVien);
                }
            }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    }
