using EditableCV.Services.DataTransferObjects.FileDto;
using EditableCV.Services.Shared;

namespace EditableCV.Services.Files;
public interface IFilesService
{
    Task<Response<Stream>> GetFileAsync(string fileName, CancellationToken cancellationToken);
    Task<Response<FileReadDto>> AddFileAsync(string fileName, Stream fileData, CancellationToken cancellationToken);
    Task<Response> DeleteFileAsync(string fileName, CancellationToken cancellationToken);
    Task<IList<FileReadDto>> GetAllFilesAsync(CancellationToken cancellationToken);
}
