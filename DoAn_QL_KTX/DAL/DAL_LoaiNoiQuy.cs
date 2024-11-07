using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using DTO;

namespace DAL
{
    public class DAL_LoaiNoiQuy
    {
        DA_QL_KTXDataContext ktx = new DA_QL_KTXDataContext();

        public DAL_LoaiNoiQuy()
        {
        }

        // Lấy danh sách loại nội quy
        public List<LoaiNoiQuy> GetAllLoaiNoiQuy()
        {
            // Lấy danh sách thực thể từ ngữ cảnh dữ liệu
            var danhSachLoaiNoiQuy = ktx.LoaiNoiQuys.ToList();

            // Chuyển đổi sang danh sách DTO
            return danhSachLoaiNoiQuy.Select(lnq => new LoaiNoiQuy
            {
                MaLoaiNQ = lnq.MaLoaiNQ,
                TenLoaiNQ = lnq.TenLoaiNQ,
                MoTa=lnq.MoTa,  
            }).ToList();
        }


        // Xem chi tiết loại nội quy
        public LoaiNoiQuy GetLoaiNoiQuyById(int maLoaiNQ)
        {
            var loaiNoiQuy = ktx.LoaiNoiQuys.FirstOrDefault(lnq => lnq.MaLoaiNQ == maLoaiNQ);
            if (loaiNoiQuy != null)
            {
                return new LoaiNoiQuy
                {
                    MaLoaiNQ = loaiNoiQuy.MaLoaiNQ,
                    TenLoaiNQ = loaiNoiQuy.TenLoaiNQ,
                    MoTa = loaiNoiQuy.MoTa,
                };
            }
            return null;
        }

        // Thêm loại nội quy
        public bool AddLoaiNoiQuy(LoaiNoiQuy loaiNoiQuy)
        {
            try
            {
                var newLoaiNoiQuy = new DTO.LoaiNoiQuy // Lưu ý: nếu bạn có một lớp khác cho DTO thì bạn cần đổi tên lớp ở đây
                {
                    MaLoaiNQ = loaiNoiQuy.MaLoaiNQ,
                    TenLoaiNQ = loaiNoiQuy.TenLoaiNQ
                };

                ktx.LoaiNoiQuys.InsertOnSubmit(newLoaiNoiQuy);
                ktx.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Sửa loại nội quy
        public bool UpdateLoaiNoiQuy(LoaiNoiQuy loaiNoiQuy)
        {
            try
            {
                var existingLoaiNoiQuy = ktx.LoaiNoiQuys.FirstOrDefault(lnq => lnq.MaLoaiNQ == loaiNoiQuy.MaLoaiNQ);
                if (existingLoaiNoiQuy != null)
                {
                    existingLoaiNoiQuy.TenLoaiNQ = loaiNoiQuy.TenLoaiNQ;

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
    }
}
