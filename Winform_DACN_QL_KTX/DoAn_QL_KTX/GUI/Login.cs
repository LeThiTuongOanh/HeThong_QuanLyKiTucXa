using BLL;
using DTO;
using GUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Login : Form
    {
      
        private BLL_DangNhap bLLDangNhap = new BLL_DangNhap();
      
        public Login()
        {
            InitializeComponent();
            btn_dangnhap.Click += Btn_dangnhap_Click;
            txt_tenDangNhap1.Text = Properties.Settings.Default.TenDangNhap;
            txt_MatKhau1.Text = Properties.Settings.Default.MatKhau;
        }

        private void Btn_dangnhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txt_tenDangNhap1.Text; // Giả định bạn có một TextBox với tên này
            string matKhau = txt_MatKhau1.Text; // Giả định bạn có một TextBox với tên này

            // Mã hóa mật khẩu bằng MD5
            string hashedPassword = Password.Create_MD5(matKhau);

            // Gọi phương thức GetTaiKhoan_Login từ BLL
            TaiKhoan taiKhoan = bLLDangNhap.GetTaiKhoan_Login(tenDangNhap, hashedPassword);

            // Kiểm tra xem tài khoản có hợp lệ không
            if (taiKhoan != null)
            {
                // Lưu thông tin đăng nhập nếu checkbox được chọn
                if (check_luu.Checked)
                {
                    Properties.Settings.Default.TenDangNhap = tenDangNhap;
                    Properties.Settings.Default.MatKhau= matKhau; // Lưu mật khẩu gốc (không nên lưu mật khẩu gốc trong thực tế)
                    Properties.Settings.Default.Save();
                }

                // Lưu thông tin vào lớp Login
                DangNhap.TenDangNhap = taiKhoan.TenDangNhap;
                DangNhap.MaTK = taiKhoan.MaTaiKhoan;
                //  Login.HoVaTen = taiKhoan.VaiTro; // Giả định bạn cần lưu VaiTro trong HoVaTen

                // Lấy vai trò dựa trên mã tài khoản
                string vaiTro = bLLDangNhap.GetVaiTroByMaTaiKhoan(taiKhoan.MaTaiKhoan);

                string chucVu = bLLDangNhap.GetChucVuByMaTaiKhoan(taiKhoan.MaTaiKhoan);

                // Kiểm tra vai trò và điều hướng
                if (vaiTro == "Admin")
                {
                    MessageBox.Show("Chào mừng Admin!", "Thông báo");
                    FormMain ft = new FormMain();

                    //GiaoDien f = new GiaoDien();
                    this.Hide();
                    ft.ShowDialog();
                }
                else if (vaiTro == "User")
                {
                    if (chucVu == "Nhân Viên Quản Lý")
                    {
                        MessageBox.Show("Chào mừng Nhân Viên Quản Lý!", "Thông báo");
                        FormMain f = new FormMain();
                        this.Hide();
                        f.ShowDialog();
                    }
                    else if (chucVu == "Nhân Viên Tuyển Sinh")
                    {
                        MessageBox.Show("Chào mừng Nhân Viên Tuyển Sinh!", "Thông báo");
                        FormNV_TuyenSinh f = new FormNV_TuyenSinh();
                        this.Hide();
                        f.ShowDialog();
                    }
                    else if (chucVu == "Nhân Viên Kế Toán")
                    {
                        MessageBox.Show("Chào mừng Nhân Viên Kế Toán!", "Thông báo");
                        From_NV_KTcs f = new From_NV_KTcs();
                        this.Hide();
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Chào mừng người dùng!", "Thông báo");
                        FormMain f = new FormMain();
                        this.Hide();
                        f.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Vai trò không hợp lệ!", "Lỗi");
                }

                //MessageBox.Show("Bạn đã đăng nhập thành công !", "Thông báo");
                //// Mở giao diện chính
                //FormMain f = new FormMain();

                ////GiaoDien f = new GiaoDien();
                //this.Hide();
                //f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo");
            }
        }
    }
}
