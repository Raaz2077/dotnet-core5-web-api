using my_book.Data.Models;
using my_book.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data.Services
{
    public class BooksService
    {
        public AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        //public List<Book> GetAllBooks()
        //{
        //    var allBooks = _context.Books.ToList();
        //    return allBooks;
        //}

        // or
        public List<Book> GetAllBooks() => _context.Books.ToList();

        public Book GetBookById(int bookId) => _context.Books.FirstOrDefault(n => n.Id == bookId);
    }
}
