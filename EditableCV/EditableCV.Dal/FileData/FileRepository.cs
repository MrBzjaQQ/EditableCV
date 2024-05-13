using EditableCV.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EditableCV.Dal.FileData
{
    internal sealed class FileRepository: RepositoryBase, IFileRepository
    {
        private readonly IResumeContext _context;

        public FileRepository(IResumeContext context): base(context)
        {
            _context = context;
        }

        public async Task CreateFileAsync(FileModel file, CancellationToken cancellationToken)
        {
            await _context.Images.AddAsync(file, cancellationToken);
        }

        public void DeleteFile(FileModel file)
        {
            _context.Images.Remove(file);
        }

        public async Task<IList<FileModel>> GetAllFilesAsync(CancellationToken cancellationToken)
        {
            return await _context.Images.ToListAsync(cancellationToken);
        }

        public async Task<FileModel?> GetFileByNameAsync(string fileName, CancellationToken cancellationToken)
        {
            return await _context.Images.FirstOrDefaultAsync(file => file.FileName == fileName, cancellationToken);
        }
    }
}
