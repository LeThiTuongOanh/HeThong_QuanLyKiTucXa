using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_TrangThietBi
    {
        private DAL_TrangThietBi dal_ttb;
        public BLL_TrangThietBi()
        {
            dal_ttb = new DAL_TrangThietBi();
        }

        public List<CT_DonNhap> GetChiTietDonNhap(string maDonNhap)
        {
            try
            {
                return dal_ttb.GetChiTietDonNhap(maDonNhap);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi từ BLL: " + ex.Message);
            }
        }

        // Phương thức gọi hàm từ DAL để lấy danh sách đơn nhập có trạng thái "Hoạt Động"
        public List<DonNhap_TTB> GetAllActiveDonNhap()
        {
            return dal_ttb.LoadAllActiveDonNhap();
        }
        // Gọi hàm lấy tất cả trang thiết bị
        public List<TrangThietBi> GetAllTrangThietBi()
        {
            return dal_ttb.GetAllTrangThietBi();
        }
        // lây tất cả chi tiết trang thiết bị ở từng phòng
        public List<CT_TrangThietBi> GetAllCT_TrangThietBi()
        {
            return dal_ttb.GetAllCT_TrangThietBi();
        }
        // Phương thức gọi DAL để lấy thông tin chi tiết trang thiết bị theo MaThietBi và MaPhong
        // Gọi phương thức GetCT_TrangThietBiByMaThietBiAndMaPhong từ DAL
        public PhieuKTTrangThietBi GetCT_TrangThietBiByMaThietBiAndMaPhong(string maThietBi, string maPhong)
        {
            try
            {
                // Gọi DAL và trả kết quả
                return dal_ttb.GetCT_TrangThietBiByMaThietBiAndMaPhong(maThietBi, maPhong);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Lỗi khi lấy thông tin từ BLL: " + ex.Message);
                return null;
            }
        }

        public List<Phong> GetAllMaPhong()
        {
            return dal_ttb.GetAllMaPhong();
        }
        // Gọi hàm lấy thông tin trang thiết bị theo mã
        public TrangThietBi GetTrangThietBiById(string maThietBi)
        {
            return dal_ttb.GetTrangThietBiById(maThietBi);
        }

        // Gọi hàm thêm trang thiết bị
        public bool AddTrangThietBi(TrangThietBi thietBi)
        {
            return dal_ttb.AddTrangThietBi(thietBi);
        }

        // Gọi hàm cập nhật trang thiết bị
        public bool UpdateTrangThietBi(TrangThietBi thietBi)
        {
            return dal_ttb.UpdateTrangThietBi(thietBi);
        }

        // Gọi hàm xóa trang thiết bị theo mã
        public bool DeleteTrangThietBi(string maThietBi)
        {
            return dal_ttb.DeleteTrangThietBi(maThietBi);
     
        }
        // Phương thức gọi DAL để lấy tên loại phòng
        public string GetTenLoaiPhong(string maPhong)
        {
            return dal_ttb.GetTenLoaiPhongByMaPhong(maPhong);
        }

        // Gọi hàm từ DAL để lấy danh sách trang thiết bị theo mã phòng
        public List<string> GetTrangThietBiByMaPhong(string maPhong)
        {
            return dal_ttb.GetTrangThietBiByMaPhong(maPhong); // Gọi trực tiếp hàm DAL
        }
        public string GetMaThietBiByTen(string tenThietBi)
        {
            // Gọi phương thức DAL để lấy mã thiết bị từ tên trang thiết bị
            return dal_ttb.GetMaThietBiByTen(tenThietBi);
        }

        // Phương thức gọi hàm GetThongTinTrangThietBi từ DAL
        public List<PhieuKTTrangThietBi> GetThongTinTrangThietBi()
        {
            return dal_ttb.GetThongTinTrangThietBi();
        }
        public List<ThongKeDonNhap> GetThongKeTheoQuy(int nam, int quy)
        {
            return dal_ttb.GetThongKeTheoQuy(nam, quy);
        }
        public List<ThongKeDonNhap> GetThongKeTongTienTheoThang(int nam)
        {
            return dal_ttb.GetThongKeTongTienTheoThang(nam);
        }

    }
}
