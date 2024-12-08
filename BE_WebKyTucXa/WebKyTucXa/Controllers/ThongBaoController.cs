using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebKyTucXa.Data;

namespace WebKyTucXa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongBaoController : ControllerBase
    {
        private readonly KyTucXaContext _context;

        public ThongBaoController(KyTucXaContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetThongBaos()
        {
            try
            {
                // Lấy danh sách thông báo từ database
                var thongBaos = await _context.ThongBao
    .OrderByDescending(tb => tb.NgayTao) // Sắp xếp theo ngày tạo giảm dần
    .ToListAsync();

                // Kiểm tra nếu không có thông báo nào
                if (!thongBaos.Any())
                {
                    return NotFound("Không có thông báo nào.");
                }

                return Ok(thongBaos); // Trả về danh sách thông báo
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Lỗi khi lấy danh sách thông báo: {ex.Message}");
            }
        }
        // Hàm hiển thị chi tiết thông báo
        [HttpGet("detail/{maThongBao}")]
        public async Task<IActionResult> GetThongBaoDetail(int maThongBao)
        {
            try
            {
                // Tìm thông báo theo MaThongBao
                var thongBao = await _context.DangThongBao
                    .FirstOrDefaultAsync(tb => tb.MaThongBao == maThongBao);

                if (thongBao == null)
                {
                    return NotFound($"Không tìm thấy thông báo với Mã Thông Báo: {maThongBao}");
                }

                return Ok(thongBao); // Trả về thông tin chi tiết của thông báo
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Lỗi khi lấy chi tiết thông báo: {ex.Message}");
            }
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchThongBaos(string tieuDe)
        {
            try
            {
                // Kiểm tra nếu tham số tieuDe rỗng
                if (string.IsNullOrEmpty(tieuDe))
                {
                    return BadRequest("Tên thông báo không được bỏ trống.");
                }

                // Lọc thông báo theo TieuDe, chuyển cả 2 chuỗi thành chữ thường trước khi so sánh
                var thongBaos = await _context.ThongBao
                    .Where(tb => tb.TieuDe.ToLower().Contains(tieuDe.ToLower())) // Chuyển chuỗi thành chữ thường trước khi so sánh
                    .OrderByDescending(tb => tb.NgayTao) // Sắp xếp theo ngày tạo giảm dần
                    .ToListAsync();

                // Kiểm tra nếu không có thông báo nào
                if (!thongBaos.Any())
                {
                    return NotFound($"Không có thông báo nào chứa từ khóa '{tieuDe}'.");
                }

                return Ok(thongBaos); // Trả về danh sách thông báo tìm thấy
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Lỗi khi tìm kiếm thông báo: {ex.Message}");
            }
        }
    }
}
