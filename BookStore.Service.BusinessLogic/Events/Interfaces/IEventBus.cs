namespace BookStore.Service.BusinessLogic.Events.Interfaces
{
    public interface IEventBus
    {
        Task Publish(IIntegrationEvent integrationEvent);
    }
}
