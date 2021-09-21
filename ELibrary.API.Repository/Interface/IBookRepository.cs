using ELibrary.API.Model;
using ELibrary.API.Model.DTO.RequestDTO;
using System.Collections.Generic;

namespace ELibrary.API.Repository
{
    public interface IBookRepository
    {
        bool AddBook(AddBookRequestDTO newbook);
        bool DeleteBook(string bookId);
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(string userId);
        IEnumerable<Book> SearchBooks(SearchBookRequestDTO searchBookRequest);
        bool UpdateBook(BookUpdateRequestDTO bookUpdate);
    }
}