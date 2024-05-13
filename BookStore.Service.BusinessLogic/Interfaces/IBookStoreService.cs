using BookStore.Domain.Models;

namespace BookStore.Service.BusinessLogic.Interfaces
{
    public interface IBookStoreService
    {
        Task<IEnumerable<Book>> SearchBooksAsync(string? author, string? isbn, string? status);
    }
}
