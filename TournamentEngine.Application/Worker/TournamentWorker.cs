using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentEngine.Infrastructure.Messaging;

namespace TournamentEngine.Application.Worker
{
    public class TournamentWorker : IHostedService
    {
        private readonly ILogger<TournamentWorker> _logger;
        private readonly IQueueManager _queueManager;

        public TournamentWorker(ILogger<TournamentWorker> logger, IQueueManager queueManager)
        {
            _logger = logger;
            _queueManager = queueManager;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var channel = await _queueManager.InitializeAsync();

            for (int i = 0; i < 20; i++)
            {
                string message = $"Hello World!{i}";
                var body = Encoding.UTF8.GetBytes(message);
                await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "spin_queue", body: body);
            }


        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
