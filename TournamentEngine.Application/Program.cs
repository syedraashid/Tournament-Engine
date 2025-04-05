using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TournamentEngine.Application.Worker;
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
        hostContext.Configuration.GetSection(MessagingConfig.SECTION));


    // services.AddSingleton<IConfiguration>(provider => hostContext.Configuration.GetSection(BackendDbConfig.CLUSTERS_SECTION + ":entraid_backend_r2c1"));
    services.AddScoped<IQueueManager,QueueManager>();
    services.AddHostedService<TournamentWorker>();
})
.ConfigureLogging((hostingContext, logging) =>
{
    logging.ClearProviders();
})
.Build();

await builder.RunAsync();