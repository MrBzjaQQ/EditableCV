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

        public async Task CreateFileAsync(Domain.Models.StoredFile file, CancellationToken cancellationToken)
        {
            await _context.Files.AddAsync(file, cancellationToken);
        }

        public void DeleteFile(Domain.Models.StoredFile file)
        {
            _context.Files.Remove(file);
        }

        public async Task<IList<Domain.Models.StoredFile>> GetAllFilesAsync(CancellationToken cancellationToken)
        {
            return await _context.Files.ToListAsync(cancellationToken);
        }

        public async Task<Domain.Models.StoredFile?> GetFileByNameAsync(string fileName, CancellationToken cancellationToken)
        {
            return await _context.Files.FirstOrDefaultAsync(file => file.FileName == fileName, cancellationToken);
        }
    }
}
