using Confluent.Kafka;
namespace OrderManagment.WebApi.Consumer
{
    public static class KafkaConsumerConfig
    {
        public static ConsumerConfig GetConfig()
        {
            return new ConsumerConfig
            {
                BootstrapServers = "localhost:9092", // Replace with your Kafka broker address
                ClientId = "KafkaExampleProducer",
                GroupId = "ConsumerGroup",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
        }
    }
}
