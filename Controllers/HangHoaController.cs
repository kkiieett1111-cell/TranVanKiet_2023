using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TranVanKiet_2023.Models;

namespace TranVanKiet_2023.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly QLHangHoaContext _context;

        public HangHoaController(QLHangHoaContext context)
        {
            _context = context;
        }

        // Câu 3
        public async Task<IActionResult> Index()
        {
            var danhSach = await _context.HangHoas
                .Include(h => h.LoaiHang)
                .Where(h => h.Gia != null && h.Gia >= 100)
                .ToListAsync();

            ViewBag.SectionTitle = "Trần Văn Kiệt";
            return View(danhSach);
        }

        // Câu 4: AJAX lọc HangHoa theo mục điều hướng
        [HttpGet]
        public async Task<IActionResult> FilterByCategory(int maLoai)
        {
            var query = _context.HangHoas
                .Include(h => h.LoaiHang)
                .Where(h => h.Gia != null && h.Gia >= 100);

            if (maLoai > 0)
            {
                query = query.Where(h => h.MaLoai == maLoai);
                ViewBag.SectionTitle = "NEW PRODUCTS";
            }
            else
            {
                ViewBag.SectionTitle = "Trần Văn Kiệt";
            }

            var ketQua = await query.ToListAsync();
            return PartialView("_DanhSachHangHoa", ketQua);
        }

        // Câu 5.1 (GET)
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }

        // Câu 5.1 & 5.2 (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                _context.HangHoas.Add(hangHoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.MaLoai = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai", hangHoa.MaLoai);
            return View(hangHoa);
        }
    }
}