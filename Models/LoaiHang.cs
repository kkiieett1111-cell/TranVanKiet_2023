using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TranVanKiet_2023.Models
{
    [Table("LoaiHang")]
    public class LoaiHang
    {
        [Key]
        public int MaLoai { get; set; }

        [Required]
        [StringLength(50)]
        public string TenLoai { get; set; } = string.Empty;

        public virtual ICollection<HangHoa> HangHoas { get; set; } = new List<HangHoa>();
    }
}
