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
    public class LoaiEntityController : ControllerBase
    {
        private readonly MyDbContext _db;

        public LoaiEntityController(MyDbContext dbContext)
        {
            _db = dbContext;
        }

        /// <summary>
        /// Get all category
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var listData = _db.Loais.ToList();
            return Ok(listData);
        }

        /// <summary>
        /// Create a Category
        /// </summary>
        /// <param name="loais"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(LoaiModels loais)
        {
            try
            {
                var createData = new Loai
                {
                    TenLoai = loais.TenLoai
                };
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

        /// <summary>
        /// Get a category by Id
        /// </summary>
        /// <param name="getById"></param>
        /// <returns></returns>
        [HttpGet("{getById}")]
        public IActionResult GetById_Details(int? getById)
        {
            if (getById == null)
            {
                return NotFound();
            }
            var queryId = _db.Loais.FirstOrDefault(n => n.MaLoai == getById);
            if (queryId == null)
            {
                return NotFound();
            }
            return Ok(new { 
                Data = queryId
            });
        }

        /// <summary>
        /// Update category by Id
        /// </summary>
        /// <param name="updateById"></param>
        /// <param name="updateModels"></param>
        /// <returns></returns>
        [HttpPut("{updateById}")]
        public IActionResult Update(int updateById, LoaiModels updateModels)
        {
            try
            {
                var queryId = _db.Loais.FirstOrDefault(n => n.MaLoai == updateById);
                if (queryId == null)
                {
                    return NotFound();
                }
                queryId.TenLoai = updateModels.TenLoai;
                _db.SaveChanges();

                return Ok(new
                {
                    Success = true,
                    Data = queryId
                });
            }
            catch
            {
                return BadRequest();
            }
        }


        //[HttpDelete("{deleteById}")]
        //public IActionResult Delete(int? deleteById)
        //{
        //    try
        //    {
        //        if (deleteById == null)
        //        {
        //            return NotFound();
        //        }
        //        var queryId = _db.Loais.FirstOrDefault(n => n.MaLoai == deleteById);
        //        if (queryId == null)
        //        {
        //            return NotFound();
        //        }
        //        _db.Loais.Remove(queryId);
        //        _db.SaveChanges();
        //        return Ok(new
        //        {
        //            Success = true
        //        });
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
