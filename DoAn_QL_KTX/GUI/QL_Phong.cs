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
        public QL_Phong()
        {
            InitializeComponent();
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

            int x = 140; 
            int y = 96; 
            int buttonWidth = 70; 
            int buttonHeight = 70;
            int margin = 20;

            //  Image roomImage1 = Image.FromFile(@"D:\DoAnChuyenNganh\QLKTX\DoAn_QuanLyKyTucXa\DoAn_QL_KTX\GUI\Resources\iconKTX.jpg");

            Image roomImage = GUI.Properties.Resources.user;

            foreach (string maPhong in danhSachMaPhong)
            {

                // Tạo Label hiển thị mã phòng phía trên button
                Label lblMaPhong = new Label
                {
                    Text =maPhong,
                    Location = new Point(x, y - 20), // Đặt vị trí trên button
                    Size = new Size(buttonWidth, 20),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                // Tạo button cho mỗi phòng
                Button btnPhong = new Button
                {
                   // Text = maPhong,
                    Image = roomImage,
                    ImageAlign = ContentAlignment.MiddleCenter,
                    TextAlign = ContentAlignment.TopCenter,
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = new Point(x, y)
                };

                // Lấy số sinh viên hiện tại trong phòng
                int soSinhVienHienTai = bll_phong.LaySoSinhVien(maPhong);

                // Giả định số sinh viên tối đa là 10 (sử dụng giá trị thực tế nếu có)
                int soSinhVienToiDa = 10;

                // Tạo label hiển thị số sinh viên dưới mỗi button
                Label lblSoSinhVien = new Label
                {
                    Text = $"{soSinhVienHienTai}/{soSinhVienToiDa} SV",
                    Location = new Point(x, y + buttonHeight + 5), // Đặt ngay dưới button
                    Size = new Size(buttonWidth, 20),
                    TextAlign = ContentAlignment.MiddleCenter
                };


                //// Gán sự kiện click cho button
                //btnPhong.Click += (sender, e) => BtnPhong_Click(sender, e, maPhong);

                this.Controls.Add(lblMaPhong);
                this.Controls.Add(btnPhong);
                this.Controls.Add(lblSoSinhVien);

                // Cập nhật vị trí X, Y cho button tiếp theo
                x += buttonWidth + margin;
                if (x + buttonWidth > this.ClientSize.Width) // Khi hết hàng, xuống dòng mới
                {
                    x = 10;
                    y += buttonHeight + margin+ 45;
                }
            }
        }


        // Xử lý khi button phòng được click
        private void BtnPhong_Click(object sender, EventArgs e, string maPhong)
        {
            MessageBox.Show($"Bạn đã chọn phòng: {maPhong}", "Thông tin phòng");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
