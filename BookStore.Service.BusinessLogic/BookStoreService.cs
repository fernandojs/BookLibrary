using BookStore.Domain.Models;
using BookStore.Repository.Interfaces;
using BookStore.Service.BusinessLogic.Events;
using BookStore.Service.BusinessLogic.Events.Interfaces;
using BookStore.Service.BusinessLogic.Events.Notifications;
using BookStore.Service.BusinessLogic.Interfaces;
using MediatR;

namespace BookStore.Service.BusinessLogic
{
    public class BookStoreService : IBookStoreService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IEventBus _eventBus;
        private readonly IMediator _mediator;

        public BookStoreService(IBookRepository bookRepository, IEventBus eventBus, IMediator mediator)
        {
            _bookRepository = bookRepository;
            _eventBus = eventBus;
            _mediator = mediator;
        }

        public async Task<IEnumerable<Book>> SearchBooksAsync(string? author, string? isbn, string? status)
        {         
            var books =  await _bookRepository.SearchBooksAsync(author, isbn, status);

            var (type, value) = DetermineSearchTypeAndValue(author, isbn, status);

            if (!string.IsNullOrEmpty(type))
            {
                await _mediator.Publish(new SearchNotification(type, value, DateTime.UtcNow.ToString()));              
            }

            return books;
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

