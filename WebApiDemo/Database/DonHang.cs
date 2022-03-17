using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Database.Enum;

namespace WebApiDemo.Database
{
    public class DonHang
    {
        //Tạo 1 contructor để khởi tạo mới 1 ChiTietDonhang,
        //để khi get ra thì không bị null mà sẽ hiển thị 1 danh rỗng
        public DonHang()
        {
            ChiTietDonhangs = new HashSet<ChiTietDonhang>();
        }

        public int MaDonHang { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime? NgayGiao { get; set; }
        public Status TinhTrangDonHang { get; set; }
        public string NguoiNhan { get; set; }
        public string DiaChi { get; set; }
        public int SoDienThoai { get; set; }

        //Tạo mối quan hệ với ChiTietDonhang
        public ICollection<ChiTietDonhang> ChiTietDonhangs { get; set; }
    }
}
