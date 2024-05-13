using BookStore.Domain.Models;
using BookStore.Repository.Interfaces;
using BookStore.Service.BusinessLogic.Interfaces;

namespace BookStore.Service.BusinessLogic
{
    public class BookStoreService : IBookStoreService
    {
        private readonly IBookRepository _bookRepository;

        public BookStoreService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> SearchBooksAsync(string? author, string? isbn, string? status)
        {         
            return await _bookRepository.SearchBooksAsync(author, isbn, status);
        }
    }
}

