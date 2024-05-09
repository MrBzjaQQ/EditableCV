using EditableCV.Infrastructure.Database;

namespace EditableCV.Dal;
public abstract class RepositoryBase(IDbContext context) : IRepository
{
    private readonly IDbContext _context = context;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
