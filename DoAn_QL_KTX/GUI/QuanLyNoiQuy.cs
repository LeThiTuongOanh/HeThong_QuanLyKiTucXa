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

namespace GUI
{
    public partial class QuanLyNoiQuy : Form
    {
        private BLL_LoaiNoiQuy bllLoaiNoiQuy;
        private BLL_NoiQuy bllNoiQuy;
        private List<NoiQuy> danhSachNoiQuy;
        private int currentIndex = 0; // Vị trí hiện tại
        public QuanLyNoiQuy()
        {
            InitializeComponent();
            this.Load += NoiQuy_Load;
            // Khởi tạo bllLoaiNoiQuy
            bllLoaiNoiQuy = new BLL_LoaiNoiQuy();
            bllNoiQuy = new BLL_NoiQuy();
        }

        private void NoiQuy_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            LoadData_noiQuy();
        
            }

        // Hàm load dữ liệu lên DataGridView
        private void LoadDataGridView()
        {
            List<LoaiNoiQuy> danhSachLoaiNoiQuy = bllLoaiNoiQuy.GetAllLoaiNoiQuy(); // Gọi BLL để lấy dữ liệu
            dataGV_LoaiNoiQuy.DataSource = danhSachLoaiNoiQuy; // Gán dữ liệu vào DataGridView
            dataGV_LoaiNoiQuy.Columns["MaLoaiNQ"].HeaderText = "Mã Loại Nội Quy"; // Đặt tên cột
            dataGV_LoaiNoiQuy.Columns["TenLoaiNQ"].HeaderText = "Tên Loại Nội Quy"; // Đặt tên cột
            dataGV_LoaiNoiQuy.Columns["MoTa"].HeaderText = "Mô Tả "; // Đặt tên cột
        }
        private void LoadData_noiQuy()
        {
            // Giả sử bạn đã có phương thức để lấy danh sách nội quy
            danhSachNoiQuy = bllNoiQuy.GetAllNoiQuy(); // Lấy dữ liệu từ BLL
            dataGV_NoiQuy.DataSource = danhSachNoiQuy; // Gán dữ liệu vào DataGridView
            dataGV_NoiQuy.Columns["MaNoiQuy"].HeaderText = "Mã Nội Quy"; // Đặt tên cột
            dataGV_NoiQuy.Columns["TenNoiQuy"].HeaderText = "TênNội Quy"; // Đặt tên cột
            dataGV_NoiQuy.Columns["HinhThucXL"].HeaderText = "Hình Thức Xử Phạt"; // Đặt tên cột
            ShowData(); // Hiển thị dữ liệu
        }
        private void ShowData()
        {
            // Xóa dữ liệu trong DataGridView trước khi hiển thị dữ liệu mới
            dataGV_NoiQuy.DataSource = null;

            // Lấy 5 bản ghi từ vị trí currentIndex
            var dataToShow = danhSachNoiQuy.Skip(currentIndex).Take(5).ToList();

            // Nếu không có bản ghi nào để hiển thị
            if (dataToShow.Count == 0)
            {
                dataGV_NoiQuy.DataSource = null;
                MessageBox.Show("Không có dữ liệu để hiển thị.");
                return;
            }

            // Gán dữ liệu vào DataGridView
            dataGV_NoiQuy.DataSource = dataToShow;

            // Cập nhật thông báo
            UpdateStatus();
        }

        private void UpdateStatus()
        {
           // lblStatus.Text = $"Đang xem bản ghi từ {currentIndex + 1} đến {Math.Min(currentIndex + 5, danhSachNoiQuy.Count)} trong tổng số {danhSachNoiQuy.Count} bản ghi.";
        }

        private void btn_truoc_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex -= 5; // Giảm 5 bản ghi
                ShowData();
            }
            else
            {
                MessageBox.Show("Bạn đang ở đầu danh sách.");
            }

        }

        private void btn_sau_Click(object sender, EventArgs e)
        {
            if (currentIndex + 5 < danhSachNoiQuy.Count)
            {
                currentIndex += 5; // Tăng 5 bản ghi
                ShowData();
            }
            else
            {
                MessageBox.Show("Bạn đang ở cuối danh sách.");
            }
        }

        private void dataGV_LoaiNoiQuy_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGV_LoaiNoiQuy.CurrentRow != null)
            {
                int maLoaiNQ = (int)dataGV_LoaiNoiQuy.CurrentRow.Cells["MaLoaiNQ"].Value;
                LoadDataNoiQuyTheoLoai(maLoaiNQ);
                LoadDataLoaiNoiQuy(maLoaiNQ);
            }
        }
        // Hàm để load dữ liệu của Nội Quy dựa trên mã loại nội quy
        private void LoadDataNoiQuyTheoLoai(int maLoaiNQ)
        {
            // Gọi phương thức trong BLL để lấy danh sách nội quy theo mã loại nội quy
            danhSachNoiQuy = bllNoiQuy.GetNoiQuyByMaLoaiNQ(maLoaiNQ);

            // Hiển thị dữ liệu vào DataGridView của Nội Quy
            dataGV_NoiQuy.DataSource = danhSachNoiQuy;
            dataGV_NoiQuy.Columns["MaNoiQuy"].HeaderText = "Mã Nội Quy"; // Đặt tên cột
            dataGV_NoiQuy.Columns["TenNoiQuy"].HeaderText = "TênNội Quy"; // Đặt tên cột
            dataGV_NoiQuy.Columns["HinhThucXL"].HeaderText = "Hình Thức Xử Phạt"; // Đặt tên cột
            ShowData();
        }
        // Hàm tải dữ liệu nội quy theo loại
        private void LoadDataLoaiNoiQuy(int maLoaiNQ)
        {
            // Lấy nội quy từ BLL dựa trên mã loại nội quy
            var noiQuy = bllLoaiNoiQuy.GetLoaiNoiQuyById(maLoaiNQ);

            // Kiểm tra và hiển thị thông tin nội quy vào các TextBox
            if (noiQuy != null)
            {
                txt_TenLoaiNoiQuy.Text = noiQuy.TenLoaiNQ;
                txt_MotaNoiQuy.Text = noiQuy.MoTa;
            }
            else
            {
                // Nếu không có dữ liệu, xóa trống các TextBox
                txt_TenLoaiNoiQuy.Clear();
                txt_MotaNoiQuy.Clear();
            }
        }

        private void dataGV_NoiQuy_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGV_NoiQuy.CurrentRow != null)
            {
                // Lấy mã nội quy từ dòng được chọn
                int maNoiQuy = (int)dataGV_NoiQuy.CurrentRow.Cells["MaNoiQuy"].Value;

                // Gọi hàm để lấy thông tin nội quy chi tiết
                var noiQuy = bllNoiQuy.GetNoiQuyById(maNoiQuy);

                // Kiểm tra và hiển thị thông tin nội quy vào các TextBox
                if (noiQuy != null)
                {
                    txt_TenNoiQuy.Text = noiQuy.TenNoiQuy;
                    txt_MucPhatTien.Text = noiQuy.MucPhatTien.ToString(); // Định dạng số tiền với 2 chữ số thập phân
                    txt_HinhThucXuPhat.Text = noiQuy.HinhThucXL;
                }
                else
                {
                    // Nếu không có dữ liệu, xóa trống các TextBox
                    txt_TenNoiQuy.Clear();
                    txt_MucPhatTien.Clear();
                    txt_HinhThucXuPhat.Clear();
                }
            }
        }
    }
}