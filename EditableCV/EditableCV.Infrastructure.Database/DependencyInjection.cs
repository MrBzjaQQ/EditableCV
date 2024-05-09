using EditableCV.Dal;
using EditableCV_backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EditableCV.Infrastructure.Database;
public static class DependencyInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, string? connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException("Connection string is required", nameof(connectionString));

        services.AddDbContext<ResumeContext>(options => options.UseNpgsql(connectionString));

        services.AddScoped<IResumeContext>(provider => provider.GetRequiredService<ResumeContext>());
        services.AddTransient<IResumeDbMigrator, ResumeDbMigrator>();

        return services;
    }

    public static async Task<IHost> MigrateDatabase(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var identityDbMigrator = scope.ServiceProvider.GetRequiredService<IResumeDbMigrator>();
        await identityDbMigrator.MigrateAsync();
        await identityDbMigrator.SeedDataAsync();
        return host;
    }
}
