using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ConsoleEfCoreExp1.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAcmeRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<AcmeDatabaseOptions>()
            .Bind(configuration.GetSection(nameof(AcmeDatabaseOptions)))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddDbContext<AcmeDbContext>((serviceProvider, dbContextOptions) =>
        {
            var options = serviceProvider.GetRequiredService<IOptions<AcmeDatabaseOptions>>();
            dbContextOptions.UseSqlServer(options.Value.ConnectionString, sqlServerContextOptions =>
            {
                sqlServerContextOptions.EnableRetryOnFailure();
            });
        });

        return services;
    }
}