using System.Threading.Tasks;

namespace EditableCV_backend.Data.Migrator;

public interface IResumeDbMigrator
{
    Task MigrateAsync();
    Task SeedDataAsync();
    Task EnsureDatabaseDeletedAsync();
}
