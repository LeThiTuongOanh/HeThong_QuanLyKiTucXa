using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class BLL_LoaiNoiQuy
    {
        private DAL_LoaiNoiQuy dalLoaiNoiQuy;

        public BLL_LoaiNoiQuy()
        {
            dalLoaiNoiQuy = new DAL_LoaiNoiQuy();
        }

        // Lấy danh sách loại nội quy
        public List<LoaiNoiQuy> GetAllLoaiNoiQuy()
        {
            return dalLoaiNoiQuy.GetAllLoaiNoiQuy();
        }

        // Xem chi tiết loại nội quy
        public LoaiNoiQuy GetLoaiNoiQuyById(int maLoaiNQ)
        {
            return dalLoaiNoiQuy.GetLoaiNoiQuyById(maLoaiNQ);
        }

        // Thêm loại nội quy
        public bool AddLoaiNoiQuy(LoaiNoiQuy loaiNoiQuy)
        {
            return dalLoaiNoiQuy.AddLoaiNoiQuy(loaiNoiQuy);
        }

        // Sửa loại nội quy
        public bool UpdateLoaiNoiQuy(LoaiNoiQuy loaiNoiQuy)
        {
            return dalLoaiNoiQuy.UpdateLoaiNoiQuy(loaiNoiQuy);
        }
    }
}
