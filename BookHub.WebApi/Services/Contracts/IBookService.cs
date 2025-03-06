using BookHub.WebApi.Dtos;
using BookHub.WebApi.Entities;

namespace BookHub.WebApi.Services.Contracts
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetAll();

        BookDto? GetById(int id);
        BookDto? GetByIsbn(string isbn);
        BookDto Create(CreateBookDto bookDto);
        BookDto? Update(int id, UpdateBookDto bookDto);
        bool Delete(int id);
    }
}
