using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Database;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaEntityController : ControllerBase
    {
        private readonly MyDbContext _db;

        public HangHoaEntityController(MyDbContext dbContext)
        {
            _db = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var hangHoaList = _db.HangHoas
                .Select(n => new HangHoaModels
                {
                    TenHangHoa = n.TenHangHoa,
                    GiaBan = n.GiaBan,
                    MoTa = n.MoTa,
                    MaLoai = n.MaLoai,
                    TenLoai = n.Loai.TenLoai
                });
            return Ok(new { 
                Success = true,
                Data = hangHoaList
            });
        }
        [HttpPost]
        public IActionResult CreateHangHoa(HangHoaModels hangHoa)
        {
            try
            {
                var createData = new HangHoa
                {
                    TenHangHoa = hangHoa.TenHangHoa,
                    MoTa = hangHoa.MoTa,
                    GiaBan = hangHoa.GiaBan,
                    MaLoai = hangHoa.MaLoai,
                };
                if (createData == null)
                {
                    return NotFound();
                }
                _db.Add(createData);
                _db.SaveChanges();

                return Ok(new { 
                    Success = true,
                    Data = createData
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{getById}")]
        public IActionResult GetById_Details(int? getById)
        {
            if (getById == null)
            {
                return NotFound();
            }
            var queryId = _db.HangHoas.FirstOrDefault(n => n.MaHangHoa == getById);
            if (queryId == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                Success = true,
                Data = queryId
            });
        }

        [HttpPut("{updateById}")]
        public IActionResult UpdateHangHoa(int? updateById, HangHoaModels hangHoaModels)
        {
            try
            {
                if (updateById == null)
                {
                    return NotFound();
                }
                var queryId = _db.HangHoas.SingleOrDefault(n => n.MaHangHoa == updateById);
                if (queryId != null)
                {
                    queryId.TenHangHoa = hangHoaModels.TenHangHoa;
                    queryId.MaLoai = hangHoaModels.MaLoai;
                    queryId.MoTa = hangHoaModels.MoTa;
                    queryId.GiaBan = hangHoaModels.GiaBan;

                    _db.SaveChanges();
                    return Ok(new
                    {
                        Success = true,
                        Data = queryId
                    });
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{deleteById}")]
        public IActionResult DeleteHangHoa(int? deleteById)
        {
            if (deleteById == null)
            {
                return NotFound();
            }
            var queryId = _db.HangHoas.FirstOrDefault(n => n.MaHangHoa == deleteById);
            if (queryId != null)
            {
                _db.HangHoas.Remove(queryId);
                _db.SaveChanges();

                return Ok(true);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
