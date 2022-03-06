using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<MaHangHoa> hangHoas = new List<MaHangHoa>();

        /// <summary>
        /// Get tất cả hàng hóa
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }

        /// <summary>
        /// Tìm 1 hàng hóa bằng id
        /// </summary>
        /// <param name="getById"></param>
        /// <returns></returns>
        [HttpGet("{getById}")]
        public IActionResult GetById(string getById)
        {
            try
            {
                var query = hangHoas.SingleOrDefault(n => n.Ma_HangHoa == Guid.Parse(getById));
                if (query == null)
                {
                    return NotFound("Not found Id");
                }
                return Ok(query);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Thêm mới hàng hóa
        /// </summary>
        /// <param name="hangHoa">tạo mới 1 object</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create_HangHoa(HangHoa hangHoa)
        {
            var createData = new MaHangHoa
            {
                Ma_HangHoa = Guid.NewGuid(),
                Name_HangHoa = hangHoa.Name_HangHoa,
                Description = hangHoa.Description,
                Price = hangHoa.Price
            };
            if (createData == null)
            {
                return NotFound();
            }
            hangHoas.Add(createData);
            return Ok(new
            {
                Success = true,
                Data = createData
            });
        }

        /// <summary>
        /// Update Hàng Hóa bằng id
        /// </summary>
        /// <param name="updateById"> update bằng Id </param>
        /// <param name="hangHoa">chỉ trả json của hanghoa còn Id thì ko cần update mà chỉ nhập</param>
        /// <returns></returns>
        [HttpPut("{updateById}")]
        public IActionResult Update_HangHoa(string updateById, HangHoa hangHoa)
        {
            try
            {
                var query = hangHoas.SingleOrDefault(n => n.Ma_HangHoa == Guid.Parse(updateById));
                if (query == null)
                {
                    return NotFound("Not found Id");
                }
                query.Name_HangHoa = hangHoa.Name_HangHoa;
                query.Price = hangHoa.Price;
                query.Description = hangHoa.Description;

                return Ok(query);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Xóa 1 hàng hóa bằng id 
        /// </summary>
        /// <param name="deleteById"></param>
        /// <returns></returns>
        [HttpDelete("{deleteById}")]
        public IActionResult Delete_HangHoa(string deleteById)
        {
            try
            {
                var query = hangHoas.SingleOrDefault(n => n.Ma_HangHoa == Guid.Parse(deleteById));
                if (query == null)
                {
                    return NotFound("Not found Id");
                }
                hangHoas.Remove(query);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
