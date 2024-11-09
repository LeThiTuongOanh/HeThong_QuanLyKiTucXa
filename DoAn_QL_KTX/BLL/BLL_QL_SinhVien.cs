using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class BLL_QL_SinhVien
    {
        DAL_QL_SinhVien dalSinhVien = new DAL_QL_SinhVien();
        public BLL_QL_SinhVien()
        {

        }

        public List<SinhVien> GetAllSinhViens()
        {
            return dalSinhVien.GetSinhViens();
        }

        public SinhVien GetSinhVienByMa(string maSinhVien)
        {
            return dalSinhVien.GetByMa(maSinhVien);
        }

        public bool AddSinhVien(SinhVien sinhVien)
        {
            return dalSinhVien.ThemSinhVien(sinhVien);
        }

       
        public bool UpdateSinhVien(SinhVien sinhVien)
        { 
            return dalSinhVien.CapNhatSinhVien(sinhVien);
        }

       
        public bool DeleteSinhVien(string maSoSinhVien)
        {
            return dalSinhVien.DeleteSinhVien(maSoSinhVien);
        }
    }
}
