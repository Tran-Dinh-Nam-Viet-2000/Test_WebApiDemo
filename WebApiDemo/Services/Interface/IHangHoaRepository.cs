using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Database;
using WebApiDemo.Models;

namespace WebApiDemo.Services.Interface
{
    public interface IHangHoaRepository
    {
        //Get toàn bộ data nên dùng IEnumerable để trả ra 
        Task<IEnumerable<HangHoaRepositoryModels>> GetAll();

        /// <summary>
        /// Tìm 1 HangHoa bằng Id, sau đó trả về 1 models
        /// </summary>
        /// <param name="hangHoaId"></param>
        /// <returns>HangHoaRepositoryModels</returns>
        Task<HangHoaRepositoryModels> GetById(int? hangHoaId);

        /// <summary>
        /// Thêm 1 HangHoa, truyền vào 1 kiểu dữ liệu HangHoa để add thẳng vào DB
        /// </summary>
        /// <param name="hangHoa"></param>
        /// <returns>HangHoa</returns>
        Task<HangHoa> CreatHangHoa(HangHoa hangHoa);

        /// <summary>
        /// Dùng để update
        /// </summary>
        /// <param name="id">Truyền vào để xác định ID nào cần được update</param>
        /// <param name="updateHangHoa">Dùng để update vào DB</param>
        /// <returns>HangHoa</returns>
        Task<HangHoa> UpdateHangHoa(int? id, HangHoa updateHangHoa);

        /// <summary>
        /// Xóa HangHoa
        /// </summary>
        /// <param name="deleteId">Truyền vào để xác định ID nào cần được xóa</param>
        void DeleteHangHoa(int deleteId);
    }
}
