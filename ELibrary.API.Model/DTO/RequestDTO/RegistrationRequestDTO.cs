using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.API.Model.DTO.RequestDTO
{
    public class RegistrationRequestDTO
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string ImageUrl { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(25)]
        public string Password { get; set; }
    }
}
