using AutoMapper;
using ELibrary.API.Data;
using ELibrary.API.Model;
using ELibrary.API.Model.DTO.RequestDTO;
using ELibrary.API.Services.ImageUploadService.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ELibrary.API.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ElibraryDbContext _context;
        private readonly IUploadImage _uploadImage;
        private readonly IMapper _mapper;

        public BookRepository(ElibraryDbContext context, IMapper mapper, IUploadImage uploadImage)
        {
            _context = context;
            _uploadImage = uploadImage;
            _mapper = mapper;
        }


        public Book GetBookById(string bookId)
        {
            return _context.Books.FirstOrDefault(book => book.Id == bookId);
        }


        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books
                    .Include(x => x.SubCategory);
        }


        public bool AddBook(AddBookRequestDTO newbook)
        {
            // Maps AddBookRequestDTO model to Book model
            Book book = _mapper.Map<Book>(newbook);
            _context.Books.Add(book);
            if (_context.SaveChanges() != 0)
                return true;
            return false;
        }



        public IEnumerable<Book> SearchBooks(SearchBookRequestDTO searchBookRequest)
        {
            // Fetches all books from the data store including their SubCategories
            var collection = _context.Books;
            string searchWord = searchBookRequest.SearchWord;

            // Gets all Books whose fields contains the search word
            var searchCollection = collection.Where(book => book.ISBN.Contains(searchWord)
                                        || book.Title.Contains(searchWord)
                                        || book.Author.Contains(searchWord)
                                        || book.Publisher.Contains(searchWord)
                                        || book.PublishedDate.ToShortDateString().Contains(searchWord));

            // Returns the a piginated collection of selected books
            return collection.Skip(searchBookRequest.PageCount * (searchBookRequest.PageNo - 1))
                             .Take(searchBookRequest.PageCount).ToList();
        }



        public bool UpdateBook(BookUpdateRequestDTO bookUpdate)
        {
            string thumbnailUrl = string.Empty;

            // Uploads the Image if there's any and assigns the Url to thumbnailUrl
            if(bookUpdate.Image!=null)
            {
                var upload = _uploadImage.ImageUploadAsync(bookUpdate.Image);
                thumbnailUrl = upload.Result.Url.ToString();
            }

            // Gets the book to be updated
            Book book = GetBookById(bookUpdate.Id);

            // Updates all fields that are not null in the Book Update Request fields.
            book.SubCategory.Name = String.IsNullOrWhiteSpace(bookUpdate.SubCategoryName) ? book.SubCategory.Name : bookUpdate.SubCategoryName;
            book.Title = String.IsNullOrWhiteSpace(bookUpdate.Title) ? book.Title : bookUpdate.Title;
            book.Author = String.IsNullOrWhiteSpace(bookUpdate.Author) ? book.Author : bookUpdate.Author;
            book.Publisher = String.IsNullOrWhiteSpace(bookUpdate.Publisher) ? book.Publisher : bookUpdate.Publisher;
            book.PublishedDate = (bookUpdate.PublishedDate == DateTime.MinValue) ?  book.PublishedDate : bookUpdate.PublishedDate;
            book.ThumbnailUrl = String.IsNullOrWhiteSpace(thumbnailUrl) ? book.ThumbnailUrl : thumbnailUrl;
            book.ShortDescription = String.IsNullOrWhiteSpace(bookUpdate.ShortDescription) ? book.ShortDescription : bookUpdate.ShortDescription;
            book.LongDescription = String.IsNullOrWhiteSpace(bookUpdate.LongDescription) ? book.LongDescription : bookUpdate.LongDescription;
            book.ISBN = String.IsNullOrWhiteSpace(bookUpdate.ISBN) ? book.ISBN : bookUpdate.ISBN;

            // Returns true if the book is successfully updated in the data store 
            _context.Books.Update(book);
            if (_context.SaveChanges() != 0)
                return true;
            return false;
        }


        public bool DeleteBook(string bookId)
        {
            // Fetches the book to be deleted from the data store
            Book book = GetBookById(bookId);

            _context.Books.Remove(book);
            _context.SaveChanges();
            if (_context.SaveChanges() != 0)
                return true;
            return false;
        }
    }
}
