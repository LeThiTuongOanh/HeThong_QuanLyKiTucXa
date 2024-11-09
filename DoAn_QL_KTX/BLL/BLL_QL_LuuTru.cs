using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class BLL_QL_LuuTru
    {
        DAL_QL_LuuTru xuly =new DAL_QL_LuuTru();
        public BLL_QL_LuuTru() { }

        public List<DangKyPhong> GetDangKyPhong()
        {
            return xuly.GetDKPhong();
        }
        public List<DangKyPhong> GetDangKyPhongTheoMaPhong(string maPhong)
        {
            return xuly.GetDangKyPhongTheoMaPhong(maPhong);
        }
        public DangKyPhong GetTheoMaSV(string maSV)
        {
            return xuly.GetTheoMaSV(maSV);
        }


        public List<DangKyPhong> LayThongTinSinhVien(string maPhong)
        {
            return xuly.LayThongTinSinhVien(maPhong);
        }

        public bool ThemDangKyPhong(DangKyPhong dkphong,SinhVien sv)
        {
            return xuly.ThemPhieuDangKy(dkphong,sv);
        }

        public bool SuaPhieuDangKyPhong(int maDangKyPhong, string columnIndex, string duLieuMoi)
        {
            //return xuly.SuaPhieuDangKy(dkphong) ;
            return xuly.SuaPhieuDangKyPhong(maDangKyPhong, columnIndex, duLieuMoi);
        }
         
        public bool XoaPhieuDangKyPhong(int dkphong)
        {
            return xuly.XoaPhieuDangKyPhong(dkphong);
         
        }

        public List<Phong> GetPhong()
        {
            return xuly.GetPhongs();
        }

        public List<LoaiPhong> GetLoais()
        {
            return xuly.GetLoaiPhongs();
        }
    }
}
