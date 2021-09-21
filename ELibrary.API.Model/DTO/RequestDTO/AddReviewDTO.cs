using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.API.Model.DTO.RequestDTO
{
    public class AddReviewDTO
    {
        public string BookId { get; set; }
        public string Comment { get; set; }
    }
}
