using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EditableCV_backend.Data.Migrator;

public class ResumeDbMigrator(ResumeContext context) : IResumeDbMigrator
{
    public async Task MigrateAsync()
    {
        await context.Database.MigrateAsync();
    }

    public Task SeedDataAsync()
    {
        // TODO - Seed Data
        return Task.CompletedTask;
    }

    public async Task EnsureDatabaseDeletedAsync()
    {
        await context.Database.EnsureDeletedAsync();
    }
}
