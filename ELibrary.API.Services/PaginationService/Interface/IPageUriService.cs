using ELibrary.API.Services.PaginationService.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.API.Services.PaginationService.Implementation
{
    public interface IPageUriService
    {        public Uri GetPageUri(PageFilter filter, string route);       
    }
}
