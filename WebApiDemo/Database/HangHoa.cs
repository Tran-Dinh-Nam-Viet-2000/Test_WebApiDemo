using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Database
{
    [Table("HangHoa")]
    public class HangHoa
    {
        //Tạo 1 contructor để khởi tạo mới 1 ChiTietDonhang,
        //để khi get ra thì không bị null mà sẽ hiển thị 1 tập hợp rỗng
        public HangHoa()
        {
            ChiTietDonhangs = new HashSet<ChiTietDonhang>();
        }

        [Key]
        [Required]
        public int MaHangHoa { get; set; }

        [Required]
        [MaxLength(50)]
        public string TenHangHoa { get; set; }

        [Range(0, double.MaxValue)]
        public double? GiaBan { get; set; }
        public string MoTa { get; set; }
        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }

        public ICollection<ChiTietDonhang> ChiTietDonhangs { get; set; }
    }
}
