using BookStore.Domain.Models;

namespace BookStore.Service.BusinessLogic.Interfaces
{
    public interface IBookStoreService
    {
        Task<IEnumerable<Book>> SearchBooksAsync(string? author, string? isbn, string? status);
        Task AddBookAsync(string title, string author, string status);
    }
}
