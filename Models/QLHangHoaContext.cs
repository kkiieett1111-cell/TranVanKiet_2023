using Microsoft.EntityFrameworkCore;
namespace TranVanKiet_2023.Models
{
    public class QLHangHoaContext : DbContext
    {
        public QLHangHoaContext(DbContextOptions options) : base(options) { }

        public DbSet<LoaiHang> LoaiHangs {  get; set; }
        public DbSet<HangHoa> HangHoas { get; set; }
    }
}
