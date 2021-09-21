using ELibrary.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Controllers
{
    public class UserController
    {
        [Route("api/[controller]")]
        [ApiController]
        public class BookController : ControllerBase
        {
            private readonly IUserRepository _userRepository;

            public BookController(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }


            /// <summary>
            /// Removes a user from the data store using the user Id
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            [HttpDelete()]
            [Authorize(Roles = "Admin")]
            public async Task<IActionResult> DeleteUserById(string id)
            {
                try
                {
                    bool result = await _userRepository.DeleteUser(id);
                    if (result == true)
                        return NoContent();
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        
    }
}
