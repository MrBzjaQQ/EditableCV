namespace EditableCV.Infrastructure.Database;
public interface IResumeDbMigrator
{
    Task MigrateAsync();
    Task SeedDataAsync();
    Task EnsureDatabaseDeletedAsync();
}
