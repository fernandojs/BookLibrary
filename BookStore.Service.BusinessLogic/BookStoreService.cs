using BookStore.Domain.Models;
using BookStore.Repository.Interfaces;
using BookStore.Service.BusinessLogic.Events;
using BookStore.Service.BusinessLogic.Events.Interfaces;
using BookStore.Service.BusinessLogic.Interfaces;

namespace BookStore.Service.BusinessLogic
{
    public class BookStoreService : IBookStoreService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IEventBus _eventBus;        

        public BookStoreService(IBookRepository bookRepository, IEventBus eventBus)
        {
            _bookRepository = bookRepository;
            _eventBus = eventBus;
        }

        public async Task<IEnumerable<Book>> SearchBooksAsync(string? author, string? isbn, string? status)
        {         
            var books =  await _bookRepository.SearchBooksAsync(author, isbn, status);

            var (type, value) = DetermineSearchTypeAndValue(author, isbn, status);

            if (!string.IsNullOrEmpty(type))
            {
                await _eventBus.Publish(new SearchEvent(type, value, DateTime.UtcNow.ToString()), "search");
            }

            return books;
        }

        public async Task AddBookAsync(string title, string author, string status)
        {
            //Add to Database
            await _bookRepository.AddBookAsync(title, author, status);

            await _eventBus.Publish(new BookCreatedEvent(title, author, status), "addBook");
        }

        private (string type, string value) DetermineSearchTypeAndValue(string? author, string? isbn, string? status)
        {
            if (!string.IsNullOrEmpty(author))
            {
                return ("author", author);
            }
            else if (!string.IsNullOrEmpty(isbn))
            {
                return ("isbn", isbn);
            }
            else if (!string.IsNullOrEmpty(status))
            {
                return ("status", status);
            }

            return (type: string.Empty, value: string.Empty);
        }
    }
}

