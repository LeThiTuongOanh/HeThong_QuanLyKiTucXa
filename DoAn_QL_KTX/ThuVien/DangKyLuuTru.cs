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
namespace ThuVien
{
    public partial class DangKyLuuTru : UserControl
    {
        BLL_QL_LuuTru xl = new BLL_QL_LuuTru();
        // Khai báo sự kiện
        public event EventHandler DaCoHoSo_Clicked;

        public DangKyLuuTru()
        {
            InitializeComponent();
            btn_daCoHoSo.Click += Btn_daCoHoSo_Click;
            this.Load += DangKyLuuTru_Load;
        }

        private void DangKyLuuTru_Load(object sender, EventArgs e)
        {
            cbo_phong.DataSource = xl.GetPhong();
            cbo_phong.DisplayMember ="TenPhong";
            cbo_phong.ValueMember = "MaPhong";
        }

        private void Btn_daCoHoSo_Click(object sender, EventArgs e)
        {
            // Gọi sự kiện nếu có người đăng ký
            DaCoHoSo_Clicked?.Invoke(this, EventArgs.Empty);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
