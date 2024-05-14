using BookStore.Service.BusinessLogic.Events.Interfaces;

namespace BookStore.Tests.Mocks
{
    public class MockEventBus : IEventBus
    {       
        public Task Publish(IIntegrationEvent integrationEvent, string topicName)
        {
            return Task.CompletedTask;
        }
    }
}
