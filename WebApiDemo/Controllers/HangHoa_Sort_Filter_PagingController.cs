using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Models;
using WebApiDemo.Services.Interface;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoa_Sort_Filter_PagingController : ControllerBase
    {
        private readonly IHangHoa_Sort_Filter_Paging _hangHoa_Sort_Filter_Paging;

        public HangHoa_Sort_Filter_PagingController(IHangHoa_Sort_Filter_Paging hangHoa_Sort_Filter_Paging)
        {
            _hangHoa_Sort_Filter_Paging = hangHoa_Sort_Filter_Paging;
        }

        //Call API và thực thi các method bên Repository
        [HttpGet]
        public async Task<List<HangHoaRepositoryModels>> GetAll(string search,
            double? from, double? to, string sorting, int page = 1)
        {
            return await _hangHoa_Sort_Filter_Paging.GetAll(search, from, to, sorting, page);
        }
    }
}
