using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranVanKiet_2023.Models;

namespace TranVanKiet_2023.ViewComponents
{
    public class LoaiHangMenuViewComponent : ViewComponent
    {
        private readonly QLHangHoaContext _context;

        public LoaiHangMenuViewComponent(QLHangHoaContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loaiHangs = await _context.LoaiHangs.OrderBy(x => x.MaLoai).ToListAsync();
            return View(loaiHangs);
        }
    }
}