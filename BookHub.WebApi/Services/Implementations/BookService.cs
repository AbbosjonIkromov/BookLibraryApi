using BookHub.WebApi.Dtos;
using BookHub.WebApi.Entities;
using BookHub.WebApi.Repository.Contracts;
using BookHub.WebApi.Services.Contracts;

namespace BookHub.WebApi.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IEnumerable<BookDto> GetAll()
        {
            var books = _bookRepository.GetAll();

            return books.Select(r => new BookDto
            {
                Title = r.Title,
                Author = r.Author,
                ISBN = r.ISBN,
                Genre = r.Genre,
                PublishedYear = r.PublishedYear,
                Price = r.Price
            });
        }

        public BookDto? GetById(int id)
        {
            var book = _bookRepository.GetById(id);

            return new BookDto()
            {
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                Genre = book.Genre,
                PublishedYear = book.PublishedYear,
                Price = book.Price
            };
        }

        public BookDto? GetByIsbn(string isbn)
        {
            var book = _bookRepository.GetByIsbn(isbn);

            return new BookDto()
            {
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                Genre = book.Genre,
                PublishedYear = book.PublishedYear,
                Price = book.Price
            };
        }

        public BookDto Create(CreateBookDto bookDto)
        { 
            var book = new Book()
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                ISBN = bookDto.ISBN,
                Genre = bookDto.Genre,
                PublishedYear = bookDto.PublishedYear,
                Price = bookDto.Price
            };

            _bookRepository.Create(book);

            return new BookDto()
            {
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                Genre = book.Genre,
                PublishedYear = book.PublishedYear,
                Price = book.Price
            };
        }

        public BookDto Update(int id, UpdateBookDto bookDto)
        {
            var book = _bookRepository.GetById(id);

            if (book is null) return new BookDto();

            book.Title = bookDto.Title;
            book.Author = bookDto.Author;
            book.ISBN = bookDto.ISBN;
            book.Genre = bookDto.Genre;
            book.PublishedYear = bookDto.PublishedYear;
            book.Price = bookDto.Price;

            _bookRepository.Update(book);

            return new BookDto()
            {
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                Genre = book.Genre,
                PublishedYear = book.PublishedYear,
                Price = book.Price
            };
        }

        public bool Delete(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book is null) return false;

            _bookRepository.Delete(book);
            return true;
        }
    }
}
