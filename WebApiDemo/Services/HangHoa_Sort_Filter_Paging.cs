using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Database;
using WebApiDemo.Models;
using WebApiDemo.Services.Interface;

namespace WebApiDemo.Services
{
    public class HangHoa_Sort_Filter_Paging : IHangHoa_Sort_Filter_Paging
    {
        private readonly MyDbContext _db;
        public static int PageSize { get; set; } = 3;

        public HangHoa_Sort_Filter_Paging(MyDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<List<HangHoaRepositoryModels>> GetAll(string search,
            double? from, double? to, string sorting, int page = 1)
        {
            //Lấy hết tất cả data và dùng AsQueryable để query đến đoạn lấy hết data thôi
            var hangHoa = _db.HangHoas.AsQueryable();

            #region PHẦN FILTER (PHẦN TÌM KIẾM)
            //sau đó kiểm tra từ Search nhập vào có hợp lệ hay ko
            if (!string.IsNullOrEmpty(search))
            {
               //nếu hợp lệ thì gán điều kiện và dùng Contains để tìm các từ trùng khớp
               hangHoa = hangHoa.Where(n => n.TenHangHoa.Contains(search));
            }
            //From và To là 2 tham số để chỉ tìm kiếm giá tiền từ đâu đến đâu
            if (from.HasValue)
            {
                hangHoa =  hangHoa.Where(n => n.GiaBan >= from);
            }
            if (to.HasValue)
            {
                hangHoa = hangHoa.Where(n => n.GiaBan <= to);
            }
            #endregion

            #region PHẦN SORTING (SẮP XẾP)
            //Check xem user có nhập value hay ko, nếu ko thì thực hiện sorting GiaBan
            if (!string.IsNullOrEmpty(sorting))
            {
                switch (sorting)
                {
                    //Tăng dần
                    case "GiaBan_Esc":
                        hangHoa = hangHoa.OrderBy(n => n.GiaBan);
                        break;
                    //Giảm dần
                    case "GiaBan_Desc":
                        hangHoa = hangHoa.OrderByDescending(n => n.GiaBan);
                        break;
                }
            }
            #endregion

            #region PAGING (PHÂN TRANG)
            //Logic chỗ này (page - 1) * PageSize = 
            //Ví dụ: trang = 2, PageSize = 3, thì (2 - 1) * 3 = 3, bỏ qua 3 data trước đó và lấy những data tiếp theo
            //Có 9 data, bỏ qua 1 2 3, lấy 4 5 6
            hangHoa = hangHoa.Skip((page - 1) * PageSize).Take(PageSize);
            #endregion

            //Khi đã Filter Sorting Paging thành công thì sẽ trả ra models cho người dùng
            var result = await hangHoa.Select(n => new HangHoaRepositoryModels
            {
                MaHangHoa = n.MaHangHoa,
                TenHangHoa = n.TenHangHoa,
                GiaBan = n.GiaBan,
                MaLoai = n.MaLoai,
                MoTa = n.MoTa,
                TenLoai = n.Loai.TenLoai
            }).ToListAsync();

            return result;
        }
    }
}
