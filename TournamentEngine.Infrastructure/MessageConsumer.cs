using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using TournamentEngine.Infrastructure.Messaging;

namespace TournamentEngine.Infrastructure
{
    public class MessageConsumer: BackgroundService
    {
        private readonly IQueueManager _queueManager;
        private readonly ILogger<MessageConsumer> _logger;

        public MessageConsumer(IQueueManager queueManager, ILogger<MessageConsumer> logger)
        {
            _queueManager = queueManager;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           var channel =  await _queueManager.InitializeAsync();    

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] Gmae--> {message}");
                return Task.CompletedTask;
            };

            await channel.BasicConsumeAsync("spin_queue", autoAck: true, consumer: consumer);
        }
    }
}
