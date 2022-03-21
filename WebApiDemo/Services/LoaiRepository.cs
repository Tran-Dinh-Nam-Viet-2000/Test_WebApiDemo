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
    public class LoaiRepository : ILoaiRepository
    {
        #region Add DbContext để kết nối DB và query các dữ liệu trong DB
        private readonly MyDbContext _db;

        public LoaiRepository(MyDbContext dbContext)
        {
            _db = dbContext;
        }
        #endregion

        #region NƠI CÁC XỬ LÝ LOGIC, SAU ĐÓ CÁC HÀM NÀY ĐƯỢC GỌI Ở CONTROLLER (API) ĐỂ THỰC THI
        public async Task<Loai> CreateLoai(Loai loaiModels)
        {
            var createData = new Loai
            {
                TenLoai = loaiModels.TenLoai
            };
            _db.Add(createData);
            await _db.SaveChangesAsync();

            return createData;
        }

        //public void DeleteLoai(int deleteId)
        //{
            
        //        var query =  _db.Loais.FirstOrDefault(n => n.MaLoai == deleteId);
                
        //            _db.Loais.Remove(query);
        //            _db.SaveChanges();

                
        //}

        public async Task<IEnumerable<LoaiRepositoryModels>> GetAll()
        {
            var data = await  _db.Loais
                .Select(n => new LoaiRepositoryModels
                {
                    MaLoai = n.MaLoai,
                    TenLoai = n.TenLoai
                }).ToListAsync();
            return data;
        }

        public async Task<LoaiRepositoryModels> GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var queryId = await _db.Loais
                .Select(x => new LoaiRepositoryModels 
                {
                    MaLoai = x.MaLoai,
                    TenLoai = x.TenLoai
                })
                .FirstOrDefaultAsync(n => n.MaLoai == id);

            return queryId;
        }

        public async Task<Loai> UpdateLoai(int? id, Loai loaiUpdate)
        {
            if (id == null)
            {
                return null;
            }
            var query = await _db.Loais.Where(n => n.MaLoai == id).FirstOrDefaultAsync();
            if (query != null)
            {
                query.TenLoai = loaiUpdate.TenLoai;
                _db.SaveChanges();
                return query;
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
