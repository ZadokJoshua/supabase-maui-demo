using BooksTracker.Models;

namespace BooksTracker.Services;

public interface IDataService
{
    Task<IEnumerable<Book>> GetBooks();
    Task CreateBook(Book book);
    Task DeleteBook(int id);
    Task UpdateBook(Book book);
}
