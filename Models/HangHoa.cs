using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TranVanKiet_2023.Models
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public int MaHang {  get; set; }

        [Required(ErrorMessage ="Vui lòng chọn loại hàng ")]
        [Display(Name ="MaLoai")]
        public int MaLoai {  get; set; }

        [Required(ErrorMessage = "Tên hàng không được để trống ")]
        [StringLength(50)]
        [Display(Name = "TenHang")]
        public string TenHang { get; set; } = string.Empty;

        [Required(ErrorMessage = "Giá không được để trống ")]
        [Range(100,5000, ErrorMessage ="Giá phải là số nằm trong khoảng từ 100 đến 5000 ")]
        [Column(TypeName ="numeric(18, 0)")]
        [Display(Name ="Gia")]
        public decimal? Gia {  get; set; }

        [Required(ErrorMessage = "Tên file ảnh không được để trống ")]
        [StringLength(100)]
        [RegularExpression(@".*\.(jpg|png|gif|tiff)$", ErrorMessage ="Tên file ảnh phải có đuôi : .jpg|.png|.gif|.tif ")]
        [Display(Name ="Anh")]
        public string? Anh {  get; set; }

        [ForeignKey(nameof(MaLoai))]
        public virtual LoaiHang? LoaiHang { get; set; }
    }
}
