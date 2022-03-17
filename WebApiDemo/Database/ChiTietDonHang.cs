using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Database
{
    public class ChiTietDonhang
    {
        //Map với 2 khóa chính của DonHang và HangHoa
        public int MaHangHoa { get; set; }
        public int MaDonHang { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }

        //Tạo mối quan hệ giữa các bảng
        //ChiTietDonhang thì map với DonHang và HangHoa
        public DonHang DonHang { get; set; }
        public HangHoa HangHoa { get; set; }
    }
}
