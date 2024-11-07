using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class BLL_QL_Phong
    {

        DAL_QL_Phong dal_phong=new DAL_QL_Phong();

        public BLL_QL_Phong()
        {
        }

        public List<string> DS_Phong()
        {
            return dal_phong.LayDanhSachPhong();
        }
        public int LaySoSinhVien(string maPhong)
        {
            return dal_phong.LaySoSV(maPhong);
        }

       
    }
}
