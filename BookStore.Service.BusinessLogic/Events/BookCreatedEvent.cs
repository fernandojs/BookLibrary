using BookStore.Service.BusinessLogic.Events.Interfaces;

namespace BookStore.Service.BusinessLogic.Events
{
    public record BookCreatedEvent(string title, string author, string status) : IIntegrationEvent;
}
