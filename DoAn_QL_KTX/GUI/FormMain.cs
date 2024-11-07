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
        public FormMain()
        {
            InitializeComponent();
        }
        private void submenu()
        {
            panel_Phong_SubMenu.Visible = false;
            panel_SinhVien_submenu.Visible = false;
            panel_DichVu_submenu.Visible = false;
            panel_NoiQuy_SubMenu.Visible = false;
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
            if (panel_NoiQuy_SubMenu.Visible == true)
            {
                panel_NoiQuy_SubMenu.Visible=false;
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
           // quanLyPhong1.Visible = true;
           // yeuCauSuaChua1.Visible = false;
          //  dangKyLuuTru1.Visible = false;
            hideSubmenu();
        }

        private void btn_SinhVien_submenu_Click(object sender, EventArgs e)
        {
            showsubmenu(panel_SinhVien_submenu);
        }

        private void btn_yeucausuachua_Click(object sender, EventArgs e)
        {
         //  quanLyPhong1.Visible = false;
          //  yeuCauSuaChua1.Visible = true;
           // dangKyLuuTru1.Visible = false;
            hideSubmenu();
        }
        
        private void btn_DK_luutru_Click(object sender, EventArgs e)
        {
           // dangKyLuuTru1.Visible = true;
           // quanLyPhong1.Visible = false;
           // yeuCauSuaChua1.Visible = false;
            hideSubmenu();
        }

        private void btn_DichVu_Click(object sender, EventArgs e)
        {

            showsubmenu(panel_DichVu_submenu);
        }

        private void btn_NoiQuy_submenu_Click(object sender, EventArgs e)
        {
            showsubmenu(panel_NoiQuy_SubMenu);
        }

        private void btn_NoiQuy_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLyNoiQuy()); 
           // quanLyPhong1.Visible = false;
            //yeuCauSuaChua1.Visible = false;
           // dangKyLuuTru1.Visible = false;


        }
        private Form currentFormChild;
        public void OpenChildForm(Form child)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();

            }
            currentFormChild = child;
            child.TopLevel = false;
            child.Dock = DockStyle.Fill;
            child.FormBorderStyle = FormBorderStyle.None;
            panel_Main.Controls.Add(child);
            panel_Main.Tag = child;
            child.BringToFront();
            child.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLyTrangThietBi());
        }
    }
}
