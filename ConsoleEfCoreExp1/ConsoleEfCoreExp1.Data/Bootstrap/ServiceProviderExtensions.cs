using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ConsoleEfCoreExp1.Data;

public static class ServiceProviderExtensions
{
    public static async Task ApplyDatabaseMigrationsAsync(this IServiceProvider serviceProvider)
    {
        var databaseOptions = serviceProvider.GetRequiredService<IOptions<AcmeDatabaseOptions>>();

        // Should the migration be run?
        if (databaseOptions?.Value.RunMigrationsOnStartup == false ||
            string.IsNullOrWhiteSpace(databaseOptions?.Value.ConnectionString))
        {
            return;
        }

        // Apply migrations at runtime: https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli#apply-migrations-at-runtime
        // This link also has a list of at least 5 reason why you should NOT run EF migrations in a production environment!
        using (var scope = serviceProvider.CreateScope())
        {
            var acmeContext = scope.ServiceProvider.GetRequiredService<AcmeDbContext>();

            await acmeContext.Database.MigrateAsync();
        }
    }
}