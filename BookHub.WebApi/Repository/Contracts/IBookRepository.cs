using BookHub.WebApi.Dtos;
using BookHub.WebApi.Entities;

namespace BookHub.WebApi.Repository.Contracts
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book? GetById(int id);
        Book? GetByIsbn(string isbn);
        void Create(Book book);
        void Update(Book book);
        void Delete(Book book);
    }
}
