using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using DTO;

namespace DAL
{
    public class DAL_QL_SinhVien
    {
        QLKTXDataContext ktx = new QLKTXDataContext();

        public DAL_QL_SinhVien() { }    

        public List<SinhVien> GetSinhViens()
        {
           return ktx.SinhViens.ToList();
        }

        public bool ThemSinhVien(SinhVien sinhVien)
        {
            try
            {
                ktx.SinhViens.InsertOnSubmit(sinhVien);
                ktx.SubmitChanges();
                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm sinh viên: " + ex.Message);
                return false; 
            }
        }

        public bool CapNhatSinhVien(SinhVien sinhVien)
        {
            try
            {
                // Tìm sinh viên trong cơ sở dữ liệu dựa vào mã sinh viên
                var sv = ktx.SinhViens.SingleOrDefault(sv1 => sv1.MaSinhVien == sinhVien.MaSinhVien);

                if (sv != null)
                {
                    // Cập nhật thông tin sinh viên
                    sv.HoTen = sinhVien.HoTen;
                    sv.CCCD = sinhVien.CCCD;
                    sv.Email = sinhVien.Email;
                    sv.SDT = sinhVien.SDT;
                    sv.NgaySinh = sinhVien.NgaySinh;
                    sv.GioiTinh = sinhVien.GioiTinh;
                    sv.HoKhauThuongTru = sinhVien.HoKhauThuongTru;
                    sv.NoiSinh = sinhVien.NoiSinh;
                    sv.GhiChu = sinhVien.GhiChu;
                    sv.TruongPhong = sinhVien.TruongPhong;
                    sv.HinhCCCDTruoc = sinhVien.HinhCCCDTruoc;
                    sv.HinhCCCDSau = sinhVien.HinhCCCDSau;
                    sv.HinhNhanDien = sinhVien.HinhNhanDien;
                    ktx.SubmitChanges();
                    return true; // Cập nhật thành công
                }
                return false; // Không tìm thấy sinh viên
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật sinh viên: " + ex.Message);
                return false; // Cập nhật thất bại
            }
        }

        public bool DeleteSinhVien(string maSoSinhVien)
        {
            try
            {
                // Tìm sinh viên cần xóa
                var sinhVien = ktx.SinhViens.SingleOrDefault(sv => sv.MaSinhVien == maSoSinhVien);

                if (sinhVien != null)
                {
                    ktx.SinhViens.DeleteOnSubmit(sinhVien);
                    ktx.SubmitChanges();
                    return true; // Xóa thành công
                }
                return false; // Không tìm thấy sinh viên
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa sinh viên: " + ex.Message);
                return false; // Xóa thất bại
            }
        }


    }
}
