using System.ComponentModel.DataAnnotations;

namespace WebKyTucXa.Model
{
    public class ThongBao
    {
        [Key]
        public int MaThongBao { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayHetHan { get; set; }
    }
}
