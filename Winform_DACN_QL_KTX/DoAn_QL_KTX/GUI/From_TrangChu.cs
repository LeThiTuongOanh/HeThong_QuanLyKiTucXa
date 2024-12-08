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
    public partial class From_TrangChu : Form
    {
        public From_TrangChu()
        {
            InitializeComponent();
            btn_DangNhap.Click += Btn_DangNhap_Click;
        }

        private void Btn_DangNhap_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            this.Hide();
            f.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
