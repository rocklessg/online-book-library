using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.API.Services.PaginationService.Implementation
{
    public class PageFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PageFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
    
}
