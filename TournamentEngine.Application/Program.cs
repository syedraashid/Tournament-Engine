using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TournamentEngine.Application.Worker;
using TournamentEngine.Infrastructure;
using TournamentEngine.Infrastructure.Config;
using TournamentEngine.Infrastructure.Messaging;

IHost builder = Host.CreateDefaultBuilder(args)
.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddEnvironmentVariables()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
})
.ConfigureServices((hostContext, services) =>
{
    services.AddOptions();
    services.Configure<MessagingConfig>(
        hostContext.Configuration.GetSection("MessagingConfig"));

    services.AddScoped<IQueueManager,QueueManager>();
    services.AddHostedService<TournamentWorker>();
    services.AddHostedService<MessageConsumer>();
})
.ConfigureLogging((hostingContext, logging) =>
{
    logging.ClearProviders();
})
.Build();

await builder.RunAsync();