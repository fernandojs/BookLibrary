using BookStore.Domain.Models;
using BookStore.Repository.Interfaces;

namespace BookStore.Tests.Mocks
{
    public class MockBookRepository : IBookRepository
    {
        public Task<Book> AddBookAsync(string author, string isbn, string status)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> SearchBooksAsync(string? author, string? isbn, string? status)
        {
            return new List<Book>
            {
                new Book { Title = "Harry Potter and the Sorcerer's Stone", FirstName = "Rowling", LastName = "J.K.",  ISBN = "9780439554930" },
            };
        }
    }
}
