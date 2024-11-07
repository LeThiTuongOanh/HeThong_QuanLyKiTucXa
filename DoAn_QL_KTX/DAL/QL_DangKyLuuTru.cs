using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using DTO;
namespace DAL
{
    public class QL_DangKyLuuTru
    {
       QLKTXDataContext ktx = new QLKTXDataContext();

        public QL_DangKyLuuTru() { }

        public List<SinhVien> GetSinhVien()
        {
            return ktx.SinhViens.ToList();
        }

        public bool ThemSinhVien(SinhVien sv)
        {
            try
            {
               ktx.SinhViens.InsertOnSubmit(sv);
                ktx.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CapNhatSinhVien(SinhVien sv)
        {
            try
            {
                var sinhvien = ktx.SinhViens.FirstOrDefault(a => a.MaSinhVien == sv.MaSinhVien);
                if (sinhvien != null)
                {
                    sinhvien.HoTen=sv.HoTen;
                    sinhvien.TruongPhong=sv.TruongPhong;
                    sinhvien.NgaySinh=sv.NgaySinh;
                    sinhvien.GioiTinh=sv.GioiTinh;
                    sinhvien.NoiSinh=sv.NoiSinh;
                    sinhvien.HoKhauThuongTru=sv.HoKhauThuongTru;
                    sinhvien.Email=sv.Email;
                    sinhvien.CCCD=sv.CCCD;
                    sinhvien.GhiChu=sv.GhiChu;
                    sinhvien.HinhCCCDTruoc=sv.HinhCCCDTruoc;
                    sinhvien.HinhCCCDSau=sv.HinhCCCDSau;
                    sinhvien.HinhNhanDien = sinhvien.HinhNhanDien;
                    ktx.SubmitChanges();
                    return true;
                }
            }
            catch
            {

                return false;
            }
            return false;
        }

        public bool XoaSinhVien(SinhVien sv)
        {
            try
            {
                var sinhvien = ktx.SinhViens.FirstOrDefault(a => a.MaSinhVien == sv.MaSinhVien); 
                if (sinhvien != null)
                {
                    ktx.SinhViens.DeleteOnSubmit(sinhvien);
                    ktx.SubmitChanges();
                    return true;
                }    
            }
            catch { return false; }
            return false;
        }

        public List<DangKyPhong> GetDKPhong()
        {
            return ktx.DangKyPhongs.ToList();
        }

        
        public bool ThemPhieuDangKy(DangKyPhong dkphong, SinhVien sv)
        {
            try
            {
                // Kiểm tra xem sinh viên có tồn tại trong hệ thống chưa
                var sinhvienTonTai = ktx.SinhViens.Any(s => s.MaSinhVien == sv.MaSinhVien);

                // Nếu sinh viên chưa tồn tại, thêm sinh viên mới
                if (!sinhvienTonTai)
                {
                    ktx.SinhViens.InsertOnSubmit(sv);
                    ktx.SubmitChanges();
                }

                // Thêm phiếu đăng ký phòng
                ktx.DangKyPhongs.InsertOnSubmit(dkphong);
                ktx.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm phiếu đăng ký: " + ex.Message);
                return false;
            }
        }


        //public bool SuaPhieuDangKy(DangKyPhong dkphong)
        //{
        //    try
        //    {
        //        var dk = ktx.DangKyPhongs.FirstOrDefault(p => p.MaDangKyPhong == dkphong.MaDangKyPhong);
        //        if (dk != null)
        //        {
        //            dk.MaPhong = dkphong.MaPhong;
        //            dk.MaSinhVien = dkphong.MaSinhVien;
        //            dk.NgayDK = dkphong.NgayDK;
        //            dk.NgayBD = dkphong.NgayBD;
        //            dk.NgayKT = dkphong.NgayKT; // Kiểm tra xem thuộc tính này có trong bảng hay không
        //            dk.Giuong = dkphong.Giuong;
        //            dk.Tang = dkphong.Tang;
        //        }    
        //    }catch
        //    {
        //        Console.WriteLine("Có lỗi");
        //        return false;

        //    }
        //    return false;
        //}
        public bool CapNhatPhieuDangKy(int maDangKyPhong, int columnName, string duLieuMoi)
        {
            try
            {
                var dkPhong = ktx.DangKyPhongs.FirstOrDefault(p => p.MaDangKyPhong == maDangKyPhong);
                if (dkPhong != null)
                {
                    DateTime? ngayDK = dkPhong.NgayDK;
                    DateTime? ngayBD = dkPhong.NgayBD;
                    DateTime? ngayKT = dkPhong.NgayKT;

                    switch (columnName)
                    {
                        case 4:
                            if (DateTime.TryParse(duLieuMoi, out DateTime ngayDangKy))
                            {
                                if (ngayBD.HasValue && ngayDangKy >= ngayBD.Value)
                                    throw new ArgumentException("Ngày đăng ký phải trước ngày bắt đầu ở.");
                                dkPhong.NgayDK = ngayDangKy;
                            }
                            else
                                throw new ArgumentException("Ngày đăng ký không hợp lệ.");
                            break;

                        case 5:
                            if (DateTime.TryParse(duLieuMoi, out DateTime ngayBatDau))
                            {
                                if (ngayDK.HasValue && ngayBatDau <= ngayDK.Value)
                                    throw new ArgumentException("Ngày bắt đầu ở phải sau ngày đăng ký.");
                                if (ngayKT.HasValue && ngayBatDau >= ngayKT.Value)
                                    throw new ArgumentException("Ngày bắt đầu ở phải trước ngày kết thúc ở.");
                                dkPhong.NgayBD = ngayBatDau;
                            }
                            else
                                throw new ArgumentException("Ngày bắt đầu ở không hợp lệ.");
                            break;

                        case 6:
                            if (DateTime.TryParse(duLieuMoi, out DateTime ngayKetThuc))
                            {
                                if (ngayBD.HasValue && ngayKetThuc <= ngayBD.Value)
                                    throw new ArgumentException("Ngày kết thúc ở phải sau ngày bắt đầu ở.");
                                dkPhong.NgayKT = ngayKetThuc;
                            }
                            else
                                throw new ArgumentException("Ngày kết thúc ở không hợp lệ.");
                            break;

                        case 7:
                            if (int.TryParse(duLieuMoi, out int giuong))
                                dkPhong.Giuong = giuong;
                            else
                                throw new ArgumentException("Giường không hợp lệ.");
                            break;
                        case 9:
                            if (int.TryParse(duLieuMoi, out int tang))
                                dkPhong.Tang = tang;
                            else
                                throw new ArgumentException("Tầng không hợp lệ.");
                            break;
                        default:
                            throw new ArgumentException("Chỉ số cột không hợp lệ.");
                    }

                    // Lưu thay đổi vào cơ sở dữ liệu
                    ktx.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật phiếu đăng ký: " + ex.Message);
            }
            return false;
        }

        public bool XoaPhieuDangKyPhong(int maDangKyPhong)
        {
            try
            {
                var dkPhong = ktx.DangKyPhongs.FirstOrDefault(p => p.MaDangKyPhong == maDangKyPhong);
                if (dkPhong != null)
                {
                    ktx.DangKyPhongs.DeleteOnSubmit(dkPhong);
                    ktx.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa phiếu đăng ký: " + ex.Message);
            }
            return false;
        }


        //phong
        public List<Phong> GetPhongs()
        {
            return ktx.Phongs.ToList();
        }

        public List<LoaiPhong> GetLoaiPhongs()
        {
            return ktx.LoaiPhongs.ToList();
        }
        }
    }
