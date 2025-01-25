using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ConfigurationManager config, ILogger logger)
    {
        string? dailyAddress = config["Addresses:Daily"];
        services.AddHttpClient<IDailyHttpClient, DailyHttpClient>((provider, client) =>
        {
            client.BaseAddress = new Uri(dailyAddress);
        });

        services.AddScoped<IDailyService, DailyService>();

        logger.LogInformation("{Project} services registered", "Infrastructure");
        return services;
    }
}