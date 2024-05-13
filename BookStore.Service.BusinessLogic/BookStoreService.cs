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
            return await _bookRepository.SearchBooksAsync(author, isbn, status);
        }

        public async Task AddBookAsync(string title, string author, string status)
        {
            //Add to Database
            await _bookRepository.AddBookAsync(title, author, status);

            await _eventBus.Publish(new BookCreatedEvent(title, author, status));
        }

    }
}

