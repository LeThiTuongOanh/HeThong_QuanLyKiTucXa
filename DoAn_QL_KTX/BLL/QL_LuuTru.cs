using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class QL_LuuTru
    {
        QL_DangKyLuuTru xuly =new QL_DangKyLuuTru();
        public QL_LuuTru() { }

        public List<DangKyPhong> GetDangKyPhong()
        {
            return xuly.GetDKPhong();
        }

        public bool ThemDangKyPhong(DangKyPhong dkphong,SinhVien sv)
        {
            return xuly.ThemPhieuDangKy(dkphong,sv);
        }

        public bool SuaPhieuDangKyPhong(int maDangKyPhong, int columnIndex, string duLieuMoi)
        {
            //return xuly.SuaPhieuDangKy(dkphong) ;
            return xuly.CapNhatPhieuDangKy(maDangKyPhong, columnIndex, duLieuMoi);
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
