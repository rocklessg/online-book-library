using ELibrary.API.Model.DTO.RequestDTO;
using ELibrary.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ELibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        /// <summary>
        /// Adds a new book to the datastore
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        [HttpPost("add-new")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNewbook([FromBody] AddBookRequestDTO newbook)
        {
            try
            {
               
                var result =  _bookRepository.AddBook(newbook);
                return Ok("Book Added Successfully");
            }
            catch (MissingFieldException errors)
            {
                return BadRequest(errors.Message);
            }
        }

        /// <summary>
        /// Removes a book from the data store using the book Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete()]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteBookById(string id)
        {
            try
            {
                bool result = _bookRepository.DeleteBook(id);
                if (result == true)
                    return NoContent();
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IActionResult UpdateBook(BookUpdateRequestDTO updatebook)
        {
            try
            {
                bool result = _bookRepository.UpdateBook(updatebook);
                if (result == true)
                    return Ok("Book Updated Successfully");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
