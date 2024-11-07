using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_NoiQuy
    {
        private DAL_NoiQuy dalNoiQuy;

        public BLL_NoiQuy()
        {
            dalNoiQuy = new DAL_NoiQuy();
        }

        // Lấy danh sách nội quy
        public List<NoiQuy> GetAllNoiQuy()
        {
            return dalNoiQuy.GetAllNoiQuy();
        }
        
        // Xem chi tiết nội quy
        public NoiQuy GetNoiQuyById(int maNoiQuy)
        {
            return dalNoiQuy.GetNoiQuyById(maNoiQuy);
        }

        // Thêm nội quy
        public bool AddNoiQuy(NoiQuy noiQuy)
        {
            return dalNoiQuy.AddNoiQuy(noiQuy);
        }

        // Sửa nội quy
        public bool UpdateNoiQuy(NoiQuy noiQuy)
        {
            return dalNoiQuy.UpdateNoiQuy(noiQuy);
        }

        // Xóa nội quy
        public bool DeleteNoiQuy(int maNoiQuy)
        {
            return dalNoiQuy.DeleteNoiQuy(maNoiQuy);
        }
        // Lấy danh sách nội quy theo mã loại nội quy
        public List<NoiQuy> GetNoiQuyByMaLoaiNQ(int maLoaiNQ)
        {
            return dalNoiQuy.GetNoiQuyByMaLoaiNQ(maLoaiNQ);
        }
    }
}
