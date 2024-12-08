namespace WebKyTucXa.Model
{
    public class DangThongBao
    {
        public int MaThongBao { get; set; } // Mã thông báo
        public string MaNhanVien { get; set; } // Mã nhân viên
        public string TieuDe { get; set; } // Tiêu đề thông báo
        public string FileTB { get; set; } // File thông báo
        public DateTime NgayDang { get; set; } // Ngày đăng thông báo
    }
}
