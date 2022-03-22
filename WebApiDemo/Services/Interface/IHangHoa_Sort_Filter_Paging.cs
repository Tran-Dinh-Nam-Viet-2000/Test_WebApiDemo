using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Models;

namespace WebApiDemo.Services.Interface
{
    public interface IHangHoa_Sort_Filter_Paging
    {
        Task<List<HangHoaRepositoryModels>> GetAll(string search,
            double? from, double? to, string sorting, int page = 1);
    }
}
