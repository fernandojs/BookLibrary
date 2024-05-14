using BookStore.Service.BusinessLogic.Events.Interfaces;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace BookStore.Service.BusinessLogic.Infra
{
    public class KafkaEventBus : IEventBus
    {        
        public string KafkaServer { get; set; } = "localhost:9092";

        public async Task Publish(IIntegrationEvent integrationEvent, string topicName)
        {
            try
            {
                var config = new ProducerConfig
                {
                    BootstrapServers = KafkaServer,
                    SocketTimeoutMs = 5000,
                    MessageTimeoutMs = 10000,
                    MessageSendMaxRetries = 2
                };

                using (var producer = new ProducerBuilder<Null, string>(config).Build())
                {
                    var result = await producer.ProduceAsync(
                        topicName,
                        new Message<Null, string>()
                        { Value = JsonConvert.SerializeObject(integrationEvent) }
                    );

                    Console.WriteLine(
                        $"Mensage: {JsonConvert.SerializeObject(integrationEvent)} | " +
                        $"Status: {result.Status.ToString()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Exception: {ex.GetType().FullName} | " +
                    $"Mensage: {ex.Message}");
            }
        }
    }
}
