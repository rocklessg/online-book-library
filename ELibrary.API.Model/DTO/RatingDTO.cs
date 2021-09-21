using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.API.Model.DTO
{
    public class RatingDTO
    {
        public string UserId { get; set; }
        public string BookId { get; set; }
        [Required]
        public double RatedValue { get; set; }
        public BookDTO Book { get; set; }
        public UserDTO User { get; set; }
    }
}
