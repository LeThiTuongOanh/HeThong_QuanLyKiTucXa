using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_QL_Phong
    {
        QLKTXDataContext ktx= new QLKTXDataContext();

        public DAL_QL_Phong() { }

        // Phương thức lấy danh sách phòng
        public List<string> LayDanhSachPhong()
        {
            return (from phong in ktx.Phongs
                    select phong.MaPhong).ToList();
        }

        public int LaySoSV(string maPhong)
        {
            return ktx.DangKyPhongs.Count(dkp=>dkp.MaPhong==maPhong);
        }
            
        //public List<string> LayDanhSachMaPhong()
        //{
        //     Lấy danh sách mã phòng từ bảng DangKyPhong
        //    return ktx.DangKyPhongs.Select(dkp => dkp.MaPhong).Distinct().ToList();
        //}
    }
}
