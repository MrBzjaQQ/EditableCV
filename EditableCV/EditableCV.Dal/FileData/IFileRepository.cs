using EditableCV.Domain.Models;

namespace EditableCV.Dal.FileData
{
    public interface IFileRepository : IRepository
    {
        Task CreateFileAsync(Domain.Models.StoredFile image, CancellationToken cancellationToken);
        void DeleteFile(Domain.Models.StoredFile image);
        Task<IList<Domain.Models.StoredFile>> GetAllFilesAsync(CancellationToken cancellationToken);
        Task<Domain.Models.StoredFile?> GetFileByNameAsync(string fileName, CancellationToken cancellationToken);
    }
}
