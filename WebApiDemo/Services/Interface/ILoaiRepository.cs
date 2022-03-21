using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Database;
using WebApiDemo.Models;

namespace WebApiDemo.Services.Interface
{
    public interface ILoaiRepository
    {
        //Get toàn bộ data nên dùng IEnumerable để trả ra 
        Task<IEnumerable<LoaiRepositoryModels>> GetAll();

        /// <summary>
        /// Tìm 1 Loai bằng Id, sau đó trả về 1 models
        /// </summary>
        /// <param name="id"></param>
        /// <returns>LoaiRepositoryModels</returns>
        Task<LoaiRepositoryModels> GetById(int? id);

        /// <summary>
        /// Thêm 1 Loai, truyền vào 1 kiểu dữ liệu Loai để add thẳng vào DB
        /// </summary>
        /// <param name="loaiModels"></param>
        /// <returns>Loai</returns>
        Task<Loai> CreateLoai(Loai loaiModels);

        /// <summary>
        /// Dùng để update
        /// </summary>
        /// <param name="id">Truyền vào để xác định ID nào cần được update</param>
        /// <param name="loaiUpdate">Dùng để update vào DB</param>
        /// <returns>Loai</returns>
        Task<Loai> UpdateLoai(int? id, Loai loaiUpdate);
        //public void DeleteLoai(int deleteId);
    }
}
