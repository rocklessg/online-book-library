using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.API.Model.DTO.ResponseDTO
{
    public class LoginResponseDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}
