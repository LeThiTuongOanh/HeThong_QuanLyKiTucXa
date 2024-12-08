using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_TrangThietBi
    {
        DA_QL_KTXDataContext ktx = new DA_QL_KTXDataContext();
        public DAL_TrangThietBi() { }
        // Lấy danh sách tất cả trang thiết bị

        public List<CT_DonNhap> GetChiTietDonNhap(string maDonNhap)
        {
            try
            {
                // Lấy danh sách chi tiết dựa trên mã đơn nhập
                var chiTietList = ktx.CT_DonNhaps
                                     .Where(ct => ct.MaDonNhap == maDonNhap)
                                     .ToList();
                return chiTietList;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy chi tiết đơn nhập: " + ex.Message);
            }
        }

        // Hàm lấy danh sách tất cả đơn nhập có trạng thái "Hoạt Động"
        public List<DonNhap_TTB> LoadAllActiveDonNhap()
        {
            try
            {
                // Lấy danh sách từ bảng DonNhap_TTB với trạng thái là "Hoạt Động"
                var activeDonNhapList = ktx.DonNhap_TTBs
                    
                    .ToList();

                return activeDonNhapList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message); // Log lỗi
                return new List<DonNhap_TTB>(); // Trả về danh sách rỗng nếu xảy ra lỗi
            }
        }
        public List<TrangThietBi> GetAllTrangThietBi()
        {
            return ktx.TrangThietBis.ToList();
        }
        //lấy danh sách tất cả chi trang thiết bị ở từng phòng ạ
        public List<CT_TrangThietBi> GetAllCT_TrangThietBi()
        {
            return ktx.CT_TrangThietBis.ToList();
        }
        // Hàm lấy thông tin chi tiết trang thiết bị theo MaThietBi và MaPhong
        public PhieuKTTrangThietBi GetCT_TrangThietBiByMaThietBiAndMaPhong(string maThietBi, string maPhong)
        {
            try
            {
                // Truy vấn kết hợp giữa bảng CT_TrangThietBi và TrangThietBi
                var result = (from ct in ktx.CT_TrangThietBis
                              join ttb in ktx.TrangThietBis on ct.MaThietBi equals ttb.MaThietBi
                              where ct.MaThietBi == maThietBi && ct.MaPhong == maPhong
                              select new
                              {
                                  ct.MaThietBi,
                                  ct.MaPhong,
                                  ct.SoLuong,
                                  TenThietBi = ttb.TenThietBi // Lấy tên thiết bị từ bảng TrangThietBi
                              }).FirstOrDefault(); // Lấy kết quả đầu tiên hoặc null nếu không tìm thấy

                // Nếu kết quả có, chuyển đổi dữ liệu về kiểu CT_TrangThietBi
                if (result != null)
                {
                    return new PhieuKTTrangThietBi
                    {
                        MaThietBi = result.MaThietBi,
                        MaPhong = result.MaPhong,
                        SoLuong = result.SoLuong,
                        TenThietBi = result.TenThietBi // Trả về tên thiết bị
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Lỗi khi truy vấn dữ liệu: " + ex.Message);
                return null;
            }
        }

        // Xem chi tiết trang thiết bị theo mã
        public TrangThietBi GetTrangThietBiById(string maThietBi)
        {
            var thietBi = ktx.TrangThietBis.FirstOrDefault(tb => tb.MaThietBi == maThietBi);
            if (thietBi != null)
            {
                return new TrangThietBi
                {
                    MaThietBi = thietBi.MaThietBi,
                    TenThietBi = thietBi.TenThietBi,
                    TrangThai = thietBi.TrangThai
                };
            }
            return null;
        }

        // Thêm trang thiết bị mới
        public bool AddTrangThietBi(TrangThietBi thietBi)
        {
            try
            {
                var newThietBi = new TrangThietBi
                {
                    MaThietBi = thietBi.MaThietBi,
                    TenThietBi = thietBi.TenThietBi,
                    TrangThai = thietBi.TrangThai
                };

                ktx.TrangThietBis.InsertOnSubmit(newThietBi);
                ktx.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Sửa thông tin trang thiết bị
        public bool UpdateTrangThietBi(TrangThietBi thietBi)
        {
            try
            {
                var existingThietBi = ktx.TrangThietBis.FirstOrDefault(tb => tb.MaThietBi == thietBi.MaThietBi);
                if (existingThietBi != null)
                {
                    existingThietBi.TenThietBi = thietBi.TenThietBi;
                    existingThietBi.TrangThai = thietBi.TrangThai;

                    ktx.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Xóa trang thiết bị theo mã
        public bool DeleteTrangThietBi(string maThietBi)
        {
            try
            {
                var thietBi = ktx.TrangThietBis.FirstOrDefault(tb => tb.MaThietBi == maThietBi);
                if (thietBi != null)
                {
                    ktx.TrangThietBis.DeleteOnSubmit(thietBi);
                    ktx.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
       
        // Lấy danh sách tất cả các phòng
        public List<Phong> GetAllMaPhong()
        {
            // Lấy danh sách tất cả các phòng từ bảng Phong
            var danhSachPhong = ktx.Phongs.ToList();
            return danhSachPhong;
        }
        // Lấy tên loại phòng theo mã phòng
        public string GetTenLoaiPhongByMaPhong(string maPhong)
        {
            // Lấy MaLoaiPhong từ bảng Phong theo MaPhong
            var maLoaiPhong = (from p in ktx.Phongs
                               where p.MaPhong == maPhong
                               select p.MaLoaiPhong).FirstOrDefault();

            // Truy vấn LINQ để lấy tên loại phòng từ bảng LoaiPhong qua MaLoaiPhong
            var tenLoaiPhong = (from lp in ktx.LoaiPhongs
                                where lp.MaLoaiPhong == maLoaiPhong
                                select lp.TenLoaiPhong).FirstOrDefault();

            return tenLoaiPhong; // Trả về tên loại phòng, nếu không tìm thấy sẽ trả về null
        }
        public List<string> GetTrangThietBiByMaPhong(string maPhong)
        {
            // Lấy MaLoaiPhong từ bảng Phong theo MaPhong
            var maLoaiPhong = (from p in ktx.Phongs
                               where p.MaPhong == maPhong
                               select p.MaLoaiPhong).FirstOrDefault();

            List<string> trangThietBiList = new List<string>();

            if (maLoaiPhong == 1) // Nếu là phòng đơn (MaLoaiPhong = 1)
            {
                // Lấy tất cả trang thiết bị, ngoại trừ Tủ Lạnh và TiVi
                trangThietBiList = (from tb in ktx.TrangThietBis
                                    where tb.TenThietBi != "Tủ Lạnh" && tb.TenThietBi != "Ti Vi"
                                    select tb.TenThietBi).ToList();
            }
            else if (maLoaiPhong == 2) // Nếu là phòng đôi (MaLoaiPhong = 2)
            {
                // Lấy tất cả trang thiết bị
                trangThietBiList = (from tb in ktx.TrangThietBis
                                    select tb.TenThietBi).ToList();
            }

            return trangThietBiList;
        }
        public string GetMaThietBiByTen(string tenThietBi)
        {
            // Truy vấn để lấy mã thiết bị từ tên trang thiết bị
            var maThietBi = (from tb in ktx.TrangThietBis
                             where tb.TenThietBi == tenThietBi
                             select tb.MaThietBi).FirstOrDefault();

            return maThietBi; // Trả về mã thiết bị, nếu không tìm thấy sẽ trả về null
        }

        // Hàm lấy danh sách thông tin mã phòng, mã thiết bị, tên thiết bị và số lượng
        public List<PhieuKTTrangThietBi> GetThongTinTrangThietBi()
        {
            // Thực hiện truy vấn LINQ để lấy dữ liệu từ các bảng kết hợp
            var query = from ct in ktx.CT_TrangThietBis
                        join tb in ktx.TrangThietBis on ct.MaThietBi equals tb.MaThietBi
                        join p in ktx.Phongs on ct.MaPhong equals p.MaPhong
                        select new PhieuKTTrangThietBi
                        {
                            MaPhong = ct.MaPhong,
                            MaThietBi = ct.MaThietBi,
                            TenThietBi = tb.TenThietBi,
                            SoLuong = ct.SoLuong
                        };

            // Trả về danh sách kết quả
            return query.ToList();
        }
        // Thống kê
        public List<ThongKeDonNhap> GetThongKeTheoQuy(int nam, int quy)
        {
            // Gọi thủ tục usp_ThongKeTheoQuy qua LINQ to SQL
            var result = ktx.ExecuteQuery<ThongKeDonNhap>(
                "EXEC usp_ThongKeSoLuongNhapTBTheoQuy @Nam = {0}, @Quy = {1}", nam, quy).ToList();

            return result;
        }

        public List<ThongKeDonNhap> GetThongKeTongTienTheoThang(int nam)
        {
            var result = ktx.ExecuteQuery<ThongKeDonNhap>(
                "EXEC usp_ThongKeTongTienTheoThang @Nam = {0}", nam).ToList();

            return result;
        }


    }
}
