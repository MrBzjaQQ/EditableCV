using EditableCV.Domain.Models;

namespace EditableCV.Dal.FileData
{
    public interface IFileRepository : IRepository
    {
        Task CreateFileAsync(FileModel image, CancellationToken cancellationToken);
        void DeleteFile(FileModel image);
        Task<IList<FileModel>> GetAllFilesAsync(CancellationToken cancellationToken);
        Task<FileModel?> GetFileByNameAsync(string fileName, CancellationToken cancellationToken);
    }
}
