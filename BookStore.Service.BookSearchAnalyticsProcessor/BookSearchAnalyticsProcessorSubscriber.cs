using Confluent.Kafka;

namespace BookStore.Service.BookSearchAnalyticsProcessor;

public class BookSearchAnalyticsProcessorSubscriber : BackgroundService
{
    public string TopicName { get; set; } = "search";
    public string KafkaServer { get; set; } = "localhost:9092";

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = KafkaServer,
            GroupId = $"processor-group-0",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        try
        {
            using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                consumer.Subscribe(TopicName);

                try
                {
                    while (true)
                    {
                        var cr = consumer.Consume(stoppingToken);
                        Console.WriteLine($"Mensagem has been read: {cr.Message.Value}");
                    }
                }
                catch (OperationCanceledException)
                {
                    consumer.Close();
                    Console.WriteLine("Operation cancaled by Consumer...");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"Exception: {ex.GetType().FullName} | " +
                $"Message: {ex.Message}"
            );
        }

    }
}