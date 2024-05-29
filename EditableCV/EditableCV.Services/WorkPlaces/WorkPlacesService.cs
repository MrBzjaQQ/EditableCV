using AutoMapper;
using EditableCV.Dal.FileData;
using EditableCV.Dal.WorkPlaceData;
using EditableCV.Domain.Models;
using EditableCV.Resources;
using EditableCV.Services.Shared;
using EditableCV.Services.WorkPlaceDto;

namespace EditableCV.Services.WorkPlaces;
internal sealed class WorkPlacesService(IWorkPlacesRepository repository, IFileRepository fileRepository, IMapper mapper) : IWorkPlacesService
{
    private readonly IWorkPlacesRepository _repository = repository;
    private readonly IFileRepository _fileRepository = fileRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IList<WorkPlaceReadDto>> GetAllWorkPlacesAsync(string fileControllerUrl, CancellationToken cancellationToken)
    {
        var workPlaces = await _repository.GetAllWorkPlacesAsync(cancellationToken);
        var result = new List<WorkPlaceReadDto>(workPlaces.Count);
        foreach (var workPlace in workPlaces)
        {
            var resultItem = _mapper.Map<WorkPlaceReadDto>(workPlace);
            if (workPlace.Logo != null)
            {
                result.Add(resultItem with { LogoUrl = FileUrlHelper.GetFileUrl(fileControllerUrl, workPlace.Logo.FileName) });
                continue;
            }

            result.Add(resultItem);
        }

        return result;
    }

    public async Task<Response<WorkPlaceReadDto>> GetWorkPlaceByIdAsync(int id, string fileControllerUrl, CancellationToken cancellationToken)
    {
        var workPlace = await _repository.GetWorkPlaceByIdAsync(id, cancellationToken);
        if (workPlace == null)
        {
            return Response<WorkPlaceReadDto>.CreateFailed(System.Net.HttpStatusCode.NotFound, string.Format(ErrorStrings.NotFoundByIdTemplate, id));
        }

        var result = _mapper.Map<WorkPlaceReadDto>(workPlace);
        if (workPlace.Logo is not null)
        {
            return Response<WorkPlaceReadDto>.CreateSuccess(result with { LogoUrl = FileUrlHelper.GetFileUrl(fileControllerUrl, workPlace.Logo.FileName) });
        }

        return Response<WorkPlaceReadDto>.CreateSuccess(_mapper.Map<WorkPlaceReadDto>(result));
    }

    public async Task<WorkPlaceReadDto> AddWorkPlaceAsync(WorkPlaceCreateDto workPlaceCreateDto, string fileControllerUrl, CancellationToken cancellationToken)
    {
        var workPlace = _mapper.Map<WorkPlace>(workPlaceCreateDto);
        if (string.IsNullOrEmpty(workPlaceCreateDto.LogoFileName))
        {
            await _repository.CreateWorkPlaceAsync(workPlace, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<WorkPlaceReadDto>(workPlace);
        }

        var file = await _fileRepository.GetFileByNameAsync(workPlaceCreateDto.LogoFileName, cancellationToken);
        if (file == null)
        {
            await _repository.CreateWorkPlaceAsync(workPlace, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<WorkPlaceReadDto>(workPlace);
        }

        workPlace.SetLogo(file);
        await _repository.CreateWorkPlaceAsync(workPlace, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<WorkPlaceReadDto>(workPlace) with { LogoUrl = FileUrlHelper.GetFileUrl(fileControllerUrl, file.FileName)};
    }

    public async Task<Response> EditWorkPlaceAsync(int id, WorkPlaceUpdateDto workPlaceUpdateDto, CancellationToken cancellationToken)
    {
        var workPlace = await _repository.GetWorkPlaceByIdAsync(id, cancellationToken);
        if (workPlace == null)
        {
            return Response.CreateFailed(System.Net.HttpStatusCode.NotFound, string.Format(ErrorStrings.NotFoundByIdTemplate, id));
        }

        _mapper.Map(workPlaceUpdateDto, workPlace);
        var result = Response.CreateSuccess(System.Net.HttpStatusCode.NoContent);
        if (string.IsNullOrEmpty(workPlaceUpdateDto.LogoFileName))
        {
            await _repository.CreateWorkPlaceAsync(workPlace, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return result;
        }

        var file = await _fileRepository.GetFileByNameAsync(workPlaceUpdateDto.LogoFileName, cancellationToken);
        if (file == null)
        {
            await _repository.CreateWorkPlaceAsync(workPlace, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return result;
        }

        workPlace.SetLogo(file);
        await _repository.CreateWorkPlaceAsync(workPlace, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task DeleteWorkPlaceAsync(int id, CancellationToken cancellationToken)
    {
        await _repository.DeleteWorkPlaceAsync(id, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
    }
}
