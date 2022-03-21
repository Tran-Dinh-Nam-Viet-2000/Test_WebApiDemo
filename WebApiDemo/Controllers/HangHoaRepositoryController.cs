using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Database;
using WebApiDemo.Models;
using WebApiDemo.Services.Interface;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaRepositoryController : ControllerBase
    {
        //Add các file Repository để gọi các phương thức ở đã viết ở Repository
        private readonly IHangHoaRepository _hangHoaRepository;

        public HangHoaRepositoryController(IHangHoaRepository hangHoaRepository)
        {
            _hangHoaRepository = hangHoaRepository;
        }

        #region TẠO RA CÁC API ĐỂ THỰC THI
        [HttpGet]
        public async Task<IEnumerable<HangHoaRepositoryModels>> GetAll()
        {
            var data = await _hangHoaRepository.GetAll();
            return data;
        }

        [HttpGet("{hangHoaId}")]
        public async Task<HangHoaRepositoryModels> GetById(int? hangHoaId)
        {
            var data = await _hangHoaRepository.GetById(hangHoaId);
            return data;
        }

        [HttpPost]
        public async Task<HangHoa> CreatHangHoa(HangHoa hangHoa)
        {
            var data = await _hangHoaRepository.CreatHangHoa(hangHoa);
            return data;
        }

        [HttpPut("{id}")]
        public async Task<HangHoa> UpdateHangHoa(int? id, HangHoa hangHoa)
        {
            var data = await _hangHoaRepository.UpdateHangHoa(id, hangHoa);
            return data;
        }

        [HttpPost("{deleteId}")]
        public void DeleteHangHoa(int deleteId)
        {
             _hangHoaRepository.DeleteHangHoa(deleteId);
        }
        
        #endregion
    }
}
