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
    public partial class FormMain : Form
    {
        private ThongTinLuuTru thongTinLuuTruForm;
        private Form currentFormChild;
        public FormMain()
        {
            InitializeComponent();
        }
      
        public void OpenChildForm(Form child)
        {
            if(currentFormChild !=null)
            {
                currentFormChild.Close();
                
            }
            currentFormChild = child;
            child.TopLevel = false;
            child.Dock=DockStyle.Fill; 
            child.FormBorderStyle = FormBorderStyle.None;
            panel_Main.Controls.Add(child);
            panel_Main.Tag=child;
            child.BringToFront();
     //       dangKyLuuTru1.Visible = false;
          // dangKyLuuTru1.SendToBack();
            child.Show();

        }

        public void LoadThongTinLuuTruForm()
        {
            // Kiểm tra nếu form đã tồn tại, giải phóng nó trước khi tạo form mới
            if (thongTinLuuTruForm != null)
            {
                thongTinLuuTruForm.Close();
                thongTinLuuTruForm.Dispose();
            }

            // Tạo instance mới của ThongTinLuuTru
            thongTinLuuTruForm = new ThongTinLuuTru();
            thongTinLuuTruForm.TopLevel = false; // Đặt TopLevel = false để hiển thị bên trong panel
            thongTinLuuTruForm.FormBorderStyle = FormBorderStyle.None; // Loại bỏ viền
            thongTinLuuTruForm.Dock = DockStyle.Fill; // Điền đầy trong panel

            // Thêm form vào panelContainer và hiển thị
            panel_Main.Controls.Clear(); // Xóa control cũ nếu có
            panel_Main.Controls.Add(thongTinLuuTruForm);
            thongTinLuuTruForm.Show();
        }

        private void DangKyLuuTru1_DaCoHoSo_Clicked(object sender, EventArgs e)
        {
           
            OpenChildForm(new ThongTinLuuTru());
        }

        private void submenu()
        {
            panel_Phong_SubMenu.Visible = false;
            panel_SinhVien_submenu.Visible = false;
            panel_DichVu_submenu.Visible = false;
        }
        private void hideSubmenu()
        {
            if (panel_Phong_SubMenu.Visible == true)
            {
                panel_Phong_SubMenu.Visible = false;
            }
            if (panel_SinhVien_submenu.Visible == true)
            {
                panel_SinhVien_submenu.Visible = false;
            }
            if(panel_DichVu_submenu.Visible==true)
            {
                panel_DichVu_submenu.Visible=false;
            }    
        }
        private void showsubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }

        }
        //phong
        private void button1_Click(object sender, EventArgs e)
        {
            showsubmenu(panel_Phong_SubMenu);
        }

        private void btn_quanlyphong_Click(object sender, EventArgs e)
        {
            quanLyPhong1.Visible = true;
            yeuCauSuaChua1.Visible = false;
            //dangKyLuuTru1.Visible = false;
            hideSubmenu();
            OpenChildForm(new QL_Phong(this));
        }

        private void btn_SinhVien_submenu_Click(object sender, EventArgs e)
        {
            showsubmenu(panel_SinhVien_submenu);
        }

        private void btn_yeucausuachua_Click(object sender, EventArgs e)
        {
           quanLyPhong1.Visible = false;
            yeuCauSuaChua1.Visible = true;
       //     dangKyLuuTru1.Visible = false;
            hideSubmenu();
        }
        
        private void btn_DK_luutru_Click(object sender, EventArgs e)
        {
     //       dangKyLuuTru1.Visible = true;
            quanLyPhong1.Visible = false;
            yeuCauSuaChua1.Visible = false;
            //  hideSubmenu();

            //  panelContainer.Controls.Clear(); // Xóa tất cả các điều khiển trong panel
            //panelContainer.Controls.Add(dangKyLuuTru1); // Thêm UserControl vào panel
            //dangKyLuuTru1.BringToFront(); // Đưa UserControl lên trên
            //dangKyLuuTru1.Visible = true; // Hiển thị UserControl

            // OpenChildForm(new DangKyLuuTru()); // Mở DangKyLuuTru như một form con
            OpenChildForm(new DangKyLuuTru(this)); // Truyền 'this' để có thể gọi phương thức OpenChildForm
            hideSubmenu(); // Ẩn các submenu khác nếu cần
        }

        private void btn_DichVu_Click(object sender, EventArgs e)
        {

            showsubmenu(panel_DichVu_submenu);
        }
    }
}
