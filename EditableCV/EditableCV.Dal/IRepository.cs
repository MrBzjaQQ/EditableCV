namespace EditableCV.Dal
{
    public interface IRepository
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
