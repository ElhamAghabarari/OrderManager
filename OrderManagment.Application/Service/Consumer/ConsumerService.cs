using Confluent.Kafka;
using MediatR;
using Microsoft.Extensions.Hosting;
using OrderManagment.Application.Service.notifications;
using OrderManagment.WebApi.Consumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Application.Service.Consumer
{
    public class ConsumerService : BackgroundService
    {
        private readonly IConsumer<Ignore, string> _consumer;
        private readonly IPublisher _publisher;
        public ConsumerService(IPublisher publisher)
        {
            _publisher = publisher;
            _consumer = new ConsumerBuilder<Ignore, string>(KafkaConsumerConfig.GetConfig()).Build();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Subscribe("topic_elham1");

            while (!stoppingToken.IsCancellationRequested)
            {
                ProcessKafkaMessage(stoppingToken);

                await Task.Delay(TimeSpan.FromSeconds(0.1), stoppingToken);
            }

            _consumer.Close();
        }

        public void ProcessKafkaMessage(CancellationToken stoppingToken)
        {
            try
            {
                var consumeResult = _consumer.Consume(stoppingToken);

                _publisher.Publish(new Notification($"Received Kafka message key: {consumeResult.Message.Key}, " +
                    $"message value: {consumeResult.Message.Value}, partition: {consumeResult.Partition}"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing Kafka message: {ex.Message}");
            }
        }
    }
}
