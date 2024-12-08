using Microsoft.EntityFrameworkCore;
using WebKyTucXa.Model;
namespace WebKyTucXa.Data
{
    public class KyTucXaContext : DbContext
    {
        public KyTucXaContext(DbContextOptions<KyTucXaContext> options) : base(options) { }
        public DbSet<ThongBao> ThongBao { get; set; }
        public DbSet<DangThongBao> DangThongBao { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình khóa chính cho bảng DangThongBao
            modelBuilder.Entity<DangThongBao>()
                .HasKey(tb => new { tb.MaThongBao, tb.MaNhanVien });

        }
    }
}
