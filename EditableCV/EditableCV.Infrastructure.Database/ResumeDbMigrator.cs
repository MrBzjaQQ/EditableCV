using EditableCV_backend.Data;
using Microsoft.EntityFrameworkCore;

namespace EditableCV.Infrastructure.Database;
internal class ResumeDbMigrator: IResumeDbMigrator
{
    private readonly ResumeContext _context;

    public ResumeDbMigrator(ResumeContext context)
    {
        _context = context;
    }

    public async Task MigrateAsync()
    {
        await _context.Database.MigrateAsync();
    }

    public Task SeedDataAsync()
    {
        // TODO - Seed Data
        return Task.CompletedTask;
    }

    public async Task EnsureDatabaseDeletedAsync()
    {
        await _context.Database.EnsureDeletedAsync();
    }
}
