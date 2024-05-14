using BookStore.Service.BusinessLogic.Events.Interfaces;
using BookStore.Service.BusinessLogic.Events.Notifications;
using MediatR;

namespace BookStore.Service.BusinessLogic.Events.Handlers
{
    public class SearchEventHandler : INotificationHandler<SearchNotification>
    {
        private readonly IEventBus _eventBus;
        public SearchEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(SearchNotification notification, CancellationToken cancellationToken)
        {
            await _eventBus.Publish(new SearchEvent(notification.Type, notification.Value, notification.SearchDate), "search");
        }
    }
}
