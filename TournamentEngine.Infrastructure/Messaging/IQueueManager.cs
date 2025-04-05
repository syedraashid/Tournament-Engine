using RabbitMQ.Client.Events;

namespace TournamentEngine.Infrastructure.Messaging
{
    public interface IQueueManager
    {
        Task InitializeAsync();
        Task<string?> GetMessageAsync();
        Task CloseAsync();
        ValueTask DisposeAsync();
        void ConsumeMessages();
        Task SendMessageAsync(string message);
    }
}