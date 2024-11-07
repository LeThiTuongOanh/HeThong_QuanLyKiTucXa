using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using DTO;

namespace DAL
{
    public class DAL_NoiQuy
    {
        DA_QL_KTXDataContext ktx = new DA_QL_KTXDataContext();

        public DAL_NoiQuy()
        {
        }

        // Lấy danh sách nội quy
        public List<NoiQuy> GetAllNoiQuy()
        {
            // Lấy danh sách thực thể từ ngữ cảnh dữ liệu
            var danhSachNoiQuy = ktx.NoiQuys.ToList();

            // Chuyển đổi sang danh sách DTO
            return danhSachNoiQuy.Select(nq => new NoiQuy
            {
                MaNoiQuy = nq.MaNoiQuy,
                TenNoiQuy = nq.TenNoiQuy,
                MucPhatTien = nq.MucPhatTien,
                HinhThucXL = nq.HinhThucXL,
                MaLoaiNQ = nq.MaLoaiNQ // Khóa ngoại
            }).ToList();
        }

        // Xem chi tiết nội quy
        public NoiQuy GetNoiQuyById(int maNoiQuy)
        {
            var noiQuy = ktx.NoiQuys.FirstOrDefault(nq => nq.MaNoiQuy == maNoiQuy);
            if (noiQuy != null)
            {
                return new NoiQuy
                {
                    MaNoiQuy = noiQuy.MaNoiQuy,
                    TenNoiQuy = noiQuy.TenNoiQuy,
                    MucPhatTien = noiQuy.MucPhatTien,
                    HinhThucXL = noiQuy.HinhThucXL,
                    MaLoaiNQ = noiQuy.MaLoaiNQ // Khóa ngoại
                };
            }
            return null;
        }

        // Thêm nội quy
        public bool AddNoiQuy(NoiQuy noiQuy)
        {
            try
            {
                var newNoiQuy = new DTO.NoiQuy // Lưu ý: nếu bạn có một lớp khác cho DTO thì bạn cần đổi tên lớp ở đây
                {
                    MaNoiQuy = noiQuy.MaNoiQuy,
                    TenNoiQuy = noiQuy.TenNoiQuy,
                    MucPhatTien = noiQuy.MucPhatTien,
                    HinhThucXL = noiQuy.HinhThucXL,
                    MaLoaiNQ = noiQuy.MaLoaiNQ // Khóa ngoại
                };

                ktx.NoiQuys.InsertOnSubmit(newNoiQuy);
                ktx.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Sửa nội quy
        public bool UpdateNoiQuy(NoiQuy noiQuy)
        {
            try
            {
                var existingNoiQuy = ktx.NoiQuys.FirstOrDefault(nq => nq.MaNoiQuy == noiQuy.MaNoiQuy);
                if (existingNoiQuy != null)
                {
                    existingNoiQuy.TenNoiQuy = noiQuy.TenNoiQuy;
                    existingNoiQuy.MucPhatTien = noiQuy.MucPhatTien;
                    existingNoiQuy.HinhThucXL = noiQuy.HinhThucXL;
                    existingNoiQuy.MaLoaiNQ = noiQuy.MaLoaiNQ; // Cập nhật khóa ngoại

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

        // Xóa nội quy
        public bool DeleteNoiQuy(int maNoiQuy)
        {
            try
            {
                var noiQuy = ktx.NoiQuys.FirstOrDefault(nq => nq.MaNoiQuy == maNoiQuy);
                if (noiQuy != null)
                {
                    ktx.NoiQuys.DeleteOnSubmit(noiQuy);
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

        // Lấy danh sách nội quy theo mã loại nội quy
        public List<NoiQuy> GetNoiQuyByMaLoaiNQ(int maLoaiNQ)
        {
            // Lấy danh sách thực thể từ ngữ cảnh dữ liệu
            var danhSachNoiQuyEntities = ktx.NoiQuys
                                             .Where(nq => nq.MaLoaiNQ == maLoaiNQ)
                                             .ToList();

            // Chuyển đổi danh sách thực thể thành danh sách DTO.NoiQuy
            var danhSachNoiQuy = danhSachNoiQuyEntities.Select(nq => new NoiQuy
            {
                MaNoiQuy = nq.MaNoiQuy,
                TenNoiQuy = nq.TenNoiQuy,
                MucPhatTien = nq.MucPhatTien,
                HinhThucXL = nq.HinhThucXL,
                MaLoaiNQ = nq.MaLoaiNQ
            }).ToList();

            return danhSachNoiQuy;
        }


    }
}
