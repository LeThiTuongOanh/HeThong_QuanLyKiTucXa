using BLL;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class ThongKeDoanhChi : Form
    {
        public ThongKeDoanhChi()
        {
            InitializeComponent();
            this.Load += ThongKeDoanhChi_Load;
            btn_ThongKeChi.Click += Btn_ThongKeChi_Click;
        }

        private void DrawChart(List<ThongKeChiPhi> thongKeChiPhi)
        {
            // Xóa các series cũ nếu có
            char1_ThongKeChi.Series.Clear();

            // Tạo các series mới cho biểu đồ
            Series seriesSuaChua = new Series("Tổng Tiền Sửa Chữa")
            {
                ChartType = SeriesChartType.Line, // Biểu đồ đường
                XValueMember = "Thang", // Lấy giá trị tháng từ ThongKeChiPhi
                YValueMembers = "TongTienSuaChua" // Lấy giá trị tổng tiền sửa chữa
            };

            Series seriesNhapTTB = new Series("Tổng Tiền Nhập TTB")
            {
                ChartType = SeriesChartType.Line, // Biểu đồ đường
                XValueMember = "Thang", // Lấy giá trị tháng từ ThongKeChiPhi
                YValueMembers = "TongTienNhapTTB" // Lấy giá trị tổng tiền nhập TTB
            };

            Series seriesMuaNguyenLieu = new Series("Tổng Tiền Mua Nguyên Liệu")
            {
                ChartType = SeriesChartType.Line, // Biểu đồ đường
                XValueMember = "Thang", // Lấy giá trị tháng từ ThongKeChiPhi
                YValueMembers = "TongTienMuaNguyenLieu" // Lấy giá trị tổng tiền mua nguyên liệu
            };

            // Thêm các series vào Chart
            char1_ThongKeChi.Series.Add(seriesSuaChua);
            char1_ThongKeChi.Series.Add(seriesNhapTTB);
            char1_ThongKeChi.Series.Add(seriesMuaNguyenLieu);

            // Cung cấp dữ liệu cho biểu đồ từ danh sách thống kê
            char1_ThongKeChi.DataSource = thongKeChiPhi;

            // Cập nhật biểu đồ
            char1_ThongKeChi.DataBind();
        }

        private void Btn_ThongKeChi_Click(object sender, EventArgs e)
        {
            // Lấy năm từ TextBox (hoặc có thể từ DateTimePicker nếu bạn sử dụng)
            int nam = int.Parse(txtNam.Text);  // Giả sử bạn có TextBox txtNam để nhập năm

            // Tạo đối tượng BLL_ThongKe
            BLL_ThongKe bllThongKe = new BLL_ThongKe();

            // Lấy danh sách thống kê chi phí từ BLL
            List<ThongKeChiPhi> thongKeChiPhi = bllThongKe.GetThongKeChiPhi(nam);

            // Gán dữ liệu vào DataGridView
            data_GV_ThongKeChi.DataSource = thongKeChiPhi;

            // Thêm cột Tháng vào DataGridView nếu chưa có
            if (!data_GV_ThongKeChi.Columns.Contains("Thang"))
            {
                DataGridViewTextBoxColumn thangColumn = new DataGridViewTextBoxColumn();
                thangColumn.Name = "Thang";
                thangColumn.HeaderText = "Tháng";
                thangColumn.DataPropertyName = "Thang"; // Tương ứng với thuộc tính Thang trong ThongKeChiPhi
                data_GV_ThongKeChi.Columns.Insert(0, thangColumn); // Thêm vào cột đầu tiên
            }

            // Cập nhật lại tiêu đề cột
            data_GV_ThongKeChi.Columns[1].HeaderText = "Tổng Tiền Sửa Chữa";
            data_GV_ThongKeChi.Columns[2].HeaderText = "Tổng Tiền Nhập TTB";
            data_GV_ThongKeChi.Columns[3].HeaderText = "Tổng Tiền Mua Nguyên Liệu";
            data_GV_ThongKeChi.Columns[4].HeaderText = "Tổng Chi Phí Tổng Cộng";

            // Vẽ biểu đồ
            DrawChart(thongKeChiPhi);
        }


        private void ThongKeDoanhChi_Load(object sender, EventArgs e)
        {
            
        }
    }
}
