using AutoMapper;
using EditableCV.Dal.FileData;
using EditableCV.Resources;
using EditableCV.Services.DataTransferObjects.FileDto;
using EditableCV.Services.Shared;

namespace EditableCV.Services.Files;
internal sealed class FilesService: IFilesService
{
    private readonly string _defaultPath;
    private readonly IFileRepository _repository;
    private readonly IMapper _mapper;

    public FilesService(IFileRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
    }

    public async Task<Response<Stream>> GetFileAsync(string fileName, CancellationToken cancellationToken)
    {
        var existingImage = await _repository.GetFileByNameAsync(fileName, cancellationToken);
        if (existingImage is null)
        {
            return Response<Stream>.CreateFailed(System.Net.HttpStatusCode.NotFound, string.Format(ErrorStrings.NotFoundByIdTemplate, fileName));
        }

        var stream = new FileStream(Path.Combine(_defaultPath, fileName), FileMode.Open, FileAccess.Read);
        return Response<Stream>.CreateSuccess(stream);
    }

    public async Task<Response<FileReadDto>> AddFileAsync(string fileName, Stream fileData, CancellationToken cancellationToken)
    {
        var existingImage = await _repository.GetFileByNameAsync(fileName, cancellationToken);
        if (existingImage is not null)
        {
            return Response<FileReadDto>.CreateFailed(System.Net.HttpStatusCode.BadRequest, ErrorStrings.ImageAlreadyExists);
        }

        var newImage = new Domain.Models.FileModel { FileName = fileName };
        await _repository.CreateFileAsync(newImage, cancellationToken);
        await using var stream = new FileStream(Path.Combine(_defaultPath, fileName), FileMode.CreateNew, FileAccess.Write);
        await fileData.CopyToAsync(stream);
        stream.Close();
        await _repository.SaveChangesAsync(cancellationToken);
        return Response<FileReadDto>.CreateSuccess(_mapper.Map<FileReadDto>(newImage));
    }

    public async Task<Response> DeleteFileAsync(string fileName, CancellationToken cancellationToken)
    {
        var existingImage = await _repository.GetFileByNameAsync(fileName, cancellationToken);
        if (existingImage is null)
        {
            return Response.CreateFailed(System.Net.HttpStatusCode.NotFound, string.Format(ErrorStrings.NotFoundByIdTemplate, fileName));
        }

        _repository.DeleteFile(existingImage);
        File.Delete(Path.Combine(_defaultPath, fileName));
        await _repository.SaveChangesAsync(cancellationToken);
        return Response.CreateSuccess(System.Net.HttpStatusCode.NoContent);
    }

    public async Task<IList<FileReadDto>> GetAllFilesAsync(CancellationToken cancellationToken)
    {
        var images = await _repository.GetAllFilesAsync(cancellationToken);
        return _mapper.Map<IList<FileReadDto>>(images);
    }
}
