using DTO;
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

namespace GUI
{
    public partial class QL_Phong : Form
    {
        BLL_QL_Phong bll_phong= new BLL_QL_Phong();
        private FormMain _mainForm; // Biến để lưu tham chiếu tới FormMain
                                    //  private ThongTinLuuTru thongTinLuuTruForm;
        public QL_Phong(FormMain mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm; // Lưu tham chiếu
            this.Load += QL_Phong_Load;


        }

        private void QL_Phong_Load(object sender, EventArgs e)
        {
            LoadPhongVaoTree();
            TaoDanhSachButtonPhong();

        }

        public void LoadPhongVaoTree()
        {
            treeView_Phong.Nodes.Clear();// xóa các node hiện tai nếu có

            List<string> dsPhong = bll_phong.DS_Phong();

            //Tạo node gốc
            TreeNode rootNode= new TreeNode("KTX");

            foreach (string maPhong in dsPhong)
            {
                // Tách tầng và phòng từ MaPhong (định dạng: KTX_<Tầng>_<Phòng>)
                string[] parts = maPhong.Split('-');
                if (parts.Length == 3)
                {
                    string tang = parts[1]; // Tầng
                    string phong = parts[2]; // Phòng

                    // Tìm hoặc thêm node tầng
                    TreeNode tangNode = rootNode.Nodes.Cast<TreeNode>().FirstOrDefault(n => n.Text == $"Tầng {tang}");

                    if (tangNode == null)
                    {
                        tangNode = new TreeNode($"Tầng {tang}");
                        rootNode.Nodes.Add(tangNode);
                    }

                    // Thêm node phòng vào node tầng
                    TreeNode phongNode = new TreeNode($"Phòng {phong}");
                    phongNode.Tag = maPhong; // Gán mã phòng vào Tag nếu cần sử dụng sau này
                    tangNode.Nodes.Add(phongNode);
                }
            }

            // Thêm rootNode vào TreeView
            treeView_Phong.Nodes.Add(rootNode);
            treeView_Phong.ExpandAll(); // Mở rộng tất cả các node    
        }

        private void TaoDanhSachButtonPhong()
        {
            List<string> danhSachMaPhong = bll_phong.DS_Phong();

            int buttonWidth = 70;
            int buttonHeight = 70;
            int margin = 20;
            int startX = 190;
            int x = startX;
            int y = 96;
            Image roomImage = Image.FromFile(@"D:\DoAnChuyenNganh\QLKTX\DoAn_QuanLyKyTucXa\DoAn_QL_KTX\GUI\Resources\iconKTX.jpg");
       //     Image roomImage = GUI.Properties.Resources.user;

            foreach (string maPhong in danhSachMaPhong)
            {
                // Tạo Label hiển thị mã phòng phía trên button
                Label lblMaPhong = new Label
                {
                    Text = maPhong,
                    Location = new Point(x, y - 20),
                    Size = new Size(buttonWidth, 20),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                // Tạo button cho mỗi phòng
                Button btnPhong = new Button
                {
                    Image = roomImage,
                    ImageAlign = ContentAlignment.MiddleCenter,
                    TextAlign = ContentAlignment.TopCenter,
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = new Point(x, y)
                };
                btnPhong.Click += (sender, e) => BtnPhong_Click(sender, e, maPhong);
                 
                // Lấy số sinh viên hiện tại trong phòng
                int soSinhVienHienTai = bll_phong.LaySoSinhVien(maPhong);
                int soSinhVienToiDa = 10;

                // Tạo label hiển thị số sinh viên dưới mỗi button
                Label lblSoSinhVien = new Label
                {
                    Text = $"{soSinhVienHienTai}/{soSinhVienToiDa} SV",
                    Location = new Point(x, y + buttonHeight + 5),
                    Size = new Size(buttonWidth, 20),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                this.Controls.Add(lblMaPhong);
                this.Controls.Add(btnPhong);
                this.Controls.Add(lblSoSinhVien);

                // Cập nhật vị trí X, Y cho button tiếp theo
                x += buttonWidth + margin;

                // Kiểm tra nếu vượt quá chiều rộng của form, xuống dòng mới và căn giữa
                if (x + buttonWidth > this.ClientSize.Width)
                {
                    x = startX; // Căn đầu dòng theo giá trị startX
                    y += buttonHeight + margin + 45;
                }
            }
        }

        private void BtnPhong_Click(object sender, EventArgs e, string maPhong)
        {
            // Khởi tạo đối tượng Frm_ChiTietPhong và truyền maPhong vào constructor
            //Frm_ChiTietPhong frmChiTietPhong = new Frm_ChiTietPhong(maPhong);

            //// Hiển thị form
            //frmChiTietPhong.Show();
            _mainForm.OpenChildForm(new Frm_ChiTietPhong(maPhong));
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
