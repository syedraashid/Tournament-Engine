using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
