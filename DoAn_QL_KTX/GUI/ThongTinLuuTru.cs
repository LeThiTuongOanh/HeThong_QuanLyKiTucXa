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
    public partial class ThongTinLuuTru : Form
    {
        QL_LuuTru xuly = new QL_LuuTru();

        public ThongTinLuuTru()
        {
            InitializeComponent();

            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
            dataGridView1.CellClick += DataGridView1_CellClick;
            this.Load += ThongTinLuuTru_Load;
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells["MaDangKyPhong"].Value != null) // Kiểm tra không null
            {
                int maDangKyPhong = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["MaDangKyPhong"].Value.ToString());
                string duLieuMoi = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                // Cập nhật dữ liệu trong cơ sở dữ liệu
                bool updateSuccess = xuly.SuaPhieuDangKyPhong(maDangKyPhong, e.ColumnIndex, duLieuMoi);
                if (updateSuccess)
                {
                    MessageBox.Show("Cập nhật thành công!");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại. Vui lòng thử lại.");
                }
            }
            else
            {
                MessageBox.Show("Mã ĐK phòng không hợp lệ.");
            }
        }

        private void ThongTinLuuTru_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = xuly.GetDangKyPhong();

            // Đặt tên hiển thị cho các cột và thiết lập ReadOnly cho các cột không được phép chỉnh sửa
            dataGridView1.Columns["MaDangKyPhong"].HeaderText = "Mã ĐK phòng";
            dataGridView1.Columns["MaDangKyPhong"].ReadOnly = true;
            dataGridView1.Columns["MaPhong"].HeaderText = "Mã phòng";
            dataGridView1.Columns["MaPhong"].ReadOnly = true;
            dataGridView1.Columns["MaSinhVien"].HeaderText = "Mã SV";
            dataGridView1.Columns["MaSinhVien"].ReadOnly = true;
            dataGridView1.Columns["NgayDK"].HeaderText = "Ngày ĐK";
            dataGridView1.Columns["NgayBD"].HeaderText = "Ngày BĐ ở";
            dataGridView1.Columns["NgayKT"].HeaderText = "Ngày KT ở";
            dataGridView1.Columns["Giuong"].HeaderText = "Giường";
            dataGridView1.Columns["Tang"].HeaderText = "Tầng";

            // Thêm cột "Sửa" nếu chưa tồn tại
            if (!dataGridView1.Columns.Contains("btnEdit"))
            {
                DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Sửa",
                    Name = "btnEdit",
                    FlatStyle = FlatStyle.Flat,
                    UseColumnTextForButtonValue = true,
                    Text = "✏️"
                };
                dataGridView1.Columns.Add(editColumn);
            }

            // Thêm cột "Xóa" nếu chưa tồn tại
            if (!dataGridView1.Columns.Contains("btnDelete"))
            {
                DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Xóa",
                    Name = "btnDelete",
                    FlatStyle = FlatStyle.Flat,
                    UseColumnTextForButtonValue = true,
                    Text = "🗑️"
                };
                dataGridView1.Columns.Add(deleteColumn);
            }

            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không xử lý header row
            {
                if (e.ColumnIndex == dataGridView1.Columns["btnEdit"].Index)
                {
                    int maDangKyPhong = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["MaDangKyPhong"].Value.ToString());
                    MessageBox.Show("Sửa thông tin cho Mã ĐK phòng: " + maDangKyPhong);
                }
                else if (e.ColumnIndex == dataGridView1.Columns["btnDelete"].Index)
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int maDKPhong = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["MaDangKyPhong"].Value.ToString());
                        bool deleteSuccess = xuly.XoaPhieuDangKyPhong(maDKPhong);
                        if (deleteSuccess)
                        {
                            MessageBox.Show("Xóa thành công!");
                            dataGridView1.DataSource = xuly.GetDangKyPhong();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại. Vui lòng thử lại.");
                        }
                    }
                }
            }
        }

        private void ThongTinLuuTru_Load_1(object sender, EventArgs e)
        {

        }
    }
}
