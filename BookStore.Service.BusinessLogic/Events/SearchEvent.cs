using BookStore.Service.BusinessLogic.Events.Interfaces;

namespace BookStore.Service.BusinessLogic.Events
{
    public record SearchEvent(string type, string value, string searchDate) : IIntegrationEvent;
}
