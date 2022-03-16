using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Database;

namespace WebApiDemo.Models
{
    public class HangHoaModels
    {
        public string TenHangHoa { get; set; }
        public double? GiaBan { get; set; }
        public string MoTa { get; set; }
        public int? MaLoai { get; set; }
        public string TenLoai { get; set; }
    }
}
