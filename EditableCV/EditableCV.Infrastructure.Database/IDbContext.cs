namespace EditableCV.Infrastructure.Database;
public interface IDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
