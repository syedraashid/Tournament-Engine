using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace TournamentEngine.Infrastructure.Messaging
{
    public interface IQueueManager
    {
        Task<IChannel> InitializeAsync();
        Task CloseAsync();
        ValueTask DisposeAsync();
    }
}