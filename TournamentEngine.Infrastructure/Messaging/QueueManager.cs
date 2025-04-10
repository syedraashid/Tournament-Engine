﻿using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using TournamentEngine.Infrastructure.Config;   

namespace TournamentEngine.Infrastructure.Messaging
{
    public class QueueManager : IQueueManager, IAsyncDisposable
    {
        private readonly MessagingConfig _messagingConfig;
        private readonly ILogger<QueueManager> _logger;
        private IConnection? _connection;
        private IChannel? _channel;
        private readonly string _queueName;
        private readonly ConnectionFactory _factory;
            
        public QueueManager(IOptions<MessagingConfig> messagingConfig, ILogger<QueueManager> logger)
        {
            _messagingConfig = messagingConfig.Value;
            _logger = logger;
            _queueName = _messagingConfig.QueueName;

            _factory = new ConnectionFactory
            {
                HostName = _messagingConfig.Host,
                UserName = _messagingConfig.Username,
                Password = _messagingConfig.Password
            };
        }

        /// <summary>
        /// Initializes the RabbitMQ connection and declares the queue asynchronously.
        /// </summary>
        public async Task<IChannel> InitializeAsync()
        {
            try
            {
                _connection = await _factory.CreateConnectionAsync();
                _channel = await _connection.CreateChannelAsync();
                 await _channel.QueueDeclareAsync(_queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
                _logger.LogInformation("RabbitMQ connection established and queue declared: {QueueName}", _queueName);
                 return _channel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to initialize RabbitMQ.");
                throw;
            }
        }

        /// <summary>
        /// Closes the RabbitMQ connection asynchronously.
        /// </summary>
        public async Task CloseAsync()
        {
            try
            {
                if (_channel != null)
                {
                    await _channel.CloseAsync();
                    await _channel.DisposeAsync();
                }

                if (_connection != null)
                {
                    await _connection.CloseAsync();
                    await _connection.DisposeAsync();
                }

                _logger.LogInformation("RabbitMQ connection closed.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while closing RabbitMQ connection.");
            }
        }

        /// <summary>
        /// Ensures the connection is disposed when the object is garbage collected.
        /// </summary>
        public async ValueTask DisposeAsync()
        {
            await CloseAsync();
        }
    }
}
