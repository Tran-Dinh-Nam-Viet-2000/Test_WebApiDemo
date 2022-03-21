using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Database;
using WebApiDemo.Models;
using WebApiDemo.Services;
using WebApiDemo.Services.Interface;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiRepositoryController : ControllerBase
    {
        //Add các file Repository để gọi các phương thức ở đã viết ở Repository
        private readonly ILoaiRepository _loaiRepository;

        public LoaiRepositoryController(ILoaiRepository loaiRepository)
        {
            _loaiRepository = loaiRepository;
        }

        #region TẠO RA CÁC API ĐỂ THỰC THI
        [HttpGet]
        public async Task<IEnumerable<LoaiRepositoryModels>> GetAll()
        {
            var data = await _loaiRepository.GetAll();
            return data;
        }

        [HttpGet("{id}")]
        public async Task<LoaiRepositoryModels> GetById(int? id)
        {

            var data = await _loaiRepository.GetById(id);
            return data;
        }

        [HttpPost]
        public async Task<Loai> CreateLoai(Loai loaiModels)
        {
            var data = await _loaiRepository.CreateLoai(loaiModels);
            return data;
        }

        [HttpPost("{id}")]
        public async Task<Loai> UpdateLoai(int? id, Loai loaiUpdate)
        {
            var data = await _loaiRepository.UpdateLoai(id, loaiUpdate);
            return data;
        }

        //[HttpPost("{deleteId}")]
        //public  void DeleteLoai(int deleteId)
        //{
        //    _loaiRepository.DeleteLoai(deleteId);
        //}

        #endregion
    }
}
