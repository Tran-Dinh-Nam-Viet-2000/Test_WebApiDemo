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
    public class HangHoaRepository : IHangHoaRepository
    {
        #region Add DbContext để kết nối DB và query các dữ liệu trong DB
        private readonly MyDbContext _db;

        public HangHoaRepository(MyDbContext dbContext)
        {
            _db = dbContext;
        }
        #endregion

        #region NƠI CÁC XỬ LÝ LOGIC, SAU ĐÓ CÁC HÀM NÀY ĐƯỢC GỌI Ở CONTROLLER (API) ĐỂ THỰC THI
        /// <summary>
        /// Hàm dùng để lấy toàn bộ data
        /// </summary>
        /// <returns> Trả về 1 models </returns>
        public async Task<IEnumerable<HangHoaRepositoryModels>> GetAll()
        {
            var query = await _db.HangHoas
                .Select(n => new HangHoaRepositoryModels
                {
                    TenHangHoa = n.TenHangHoa,
                    MaHangHoa = n.MaHangHoa,
                    MaLoai = n.MaLoai,
                    GiaBan = n.GiaBan,
                    MoTa = n.MoTa,
                    TenLoai = n.Loai.TenLoai
                }).ToListAsync();
            return query;
        }

        /// <summary>
        /// Tìm 1 HangHoa bằng Id, sau đó trả về 1 models
        /// </summary>
        /// <param name="hangHoaId"> Tìm bằng ID </param>
        /// <returns></returns>
        public async Task<HangHoaRepositoryModels> GetById(int? hangHoaId)
        {
            if (hangHoaId == null)
            {
                return null;
            }
            var query = await _db.HangHoas
                    .Select(n => new HangHoaRepositoryModels
                    {
                        MaHangHoa = n.MaHangHoa,
                        TenHangHoa = n.TenHangHoa,
                        MaLoai = n.MaLoai,
                        GiaBan = n.GiaBan,
                        MoTa = n.MoTa,
                    }).FirstOrDefaultAsync(n => n.MaHangHoa == hangHoaId);
            
            return query;
        }

        /// <summary>
        /// Thêm 1 HangHoa
        /// </summary>
        /// <param name="hangHoa"> truyền vào 1 kiểu dữ liệu HangHoa để add thẳng vào DB </param>
        /// <returns></returns>
        public async Task<HangHoa> CreatHangHoa(HangHoa hangHoa)
        {
            var create = new HangHoa
            {
                TenHangHoa = hangHoa.TenHangHoa,
                GiaBan = hangHoa.GiaBan,
                MaLoai = hangHoa.MaLoai,
                MoTa = hangHoa.MoTa,
            };
            _db.Add(create);
            await _db.SaveChangesAsync();

            return create;
        }

        /// <summary>
        /// Dùng để update
        /// </summary>
        /// <param name="id">Truyền vào để xác định ID nào cần được update</param>
        /// <param name="updateHangHoa">Dùng để update vào DB</param>
        /// <returns></returns>
        public async Task<HangHoa> UpdateHangHoa(int? id, HangHoa updateHangHoa)
        {
            if (id == null)
            {
                return null;
            }
            var queryId = await _db.HangHoas
                .Where(n => n.MaHangHoa == id).FirstOrDefaultAsync();
            if (queryId == null)
            {
                return null;
            }
            queryId.TenHangHoa = updateHangHoa.TenHangHoa;
            queryId.GiaBan = updateHangHoa.GiaBan;
            queryId.MaLoai = updateHangHoa.MaLoai;
            queryId.MoTa = updateHangHoa.MoTa;

            _db.SaveChanges();

            return queryId;
        }

        /// <summary>
        /// Xóa HangHoa, Vì hàm void nên không có kiểu trả về
        /// </summary>
        /// <param name="deleteId">Truyền vào để xác định ID nào cần được xóa</param>
        public void DeleteHangHoa(int deleteId)
        {
            var query = _db.HangHoas
                .SingleOrDefault(n => n.MaHangHoa == deleteId);

            _db.Remove(query);
            _db.SaveChanges();
        }

        #endregion
    }
}
