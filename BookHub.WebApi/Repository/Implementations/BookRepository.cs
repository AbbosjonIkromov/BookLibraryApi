using BookHub.WebApi.Data;
using BookHub.WebApi.Dtos;
using BookHub.WebApi.Entities;
using BookHub.WebApi.Entities.Enums;
using BookHub.WebApi.Repository.Contracts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BookHub.WebApi.Repository.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly BookHubContext _context;

        public BookRepository(BookHubContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books
                .AsNoTracking()
                .ToList();
        }

        public Book? GetById(int id)
        {
            return _context.Books
                .FirstOrDefault(r => r.Id == id);
        }

        public Book? GetByIsbn(string isbn)
        {
            return _context.Books
                .FirstOrDefault(r => r.ISBN.Equals(isbn));
        }

        public void Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
            
        }

        public void Delete(Book book)
        { 
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

    }
}
