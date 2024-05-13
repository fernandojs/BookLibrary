using BookStore.Domain.Models;
using BookStore.Repository.Interfaces;
using BookStore.Service.BusinessLogic.EventArgs;
using BookStore.Service.BusinessLogic.Interfaces;

namespace BookStore.Service.BusinessLogic
{
    public class BookStoreService : IBookStoreService
    {
        private readonly IBookRepository _bookRepository;
        private readonly INotificationService _notificationService;
        public event EventHandler<BookEventArgs> BookAdded;

        public BookStoreService(IBookRepository bookRepository, INotificationService notificationService)
        {
            _bookRepository = bookRepository;
            _notificationService = notificationService;
            BookAdded += _notificationService.OnBookAdded;
        }

        public async Task<IEnumerable<Book>> SearchBooksAsync(string? author, string? isbn, string? status)
        {         
            return await _bookRepository.SearchBooksAsync(author, isbn, status);
        }

        public async Task AddBookAsync(string title, string author, string status)
        {
            //Add to Database
            await _bookRepository.AddBookAsync(title, author, status);
            
            OnBookAdded(new BookEventArgs(title, author, status));
        }

        protected virtual void OnBookAdded(BookEventArgs e)
        {
            BookAdded?.Invoke(this, e);
        }
    }
}

