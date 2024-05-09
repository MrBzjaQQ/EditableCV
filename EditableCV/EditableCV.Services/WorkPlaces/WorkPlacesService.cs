using AutoMapper;
using EditableCV.Dal.WorkPlaceData;
using EditableCV.Domain.Models;
using EditableCV.Resources;
using EditableCV.Services.Shared;
using EditableCV.Services.WorkPlaceDto;

namespace EditableCV.Services.WorkPlaces;
internal sealed class WorkPlacesService(IWorkPlacesRepository repository, IMapper mapper) : IWorkPlacesService
{
    private readonly IWorkPlacesRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<IList<WorkPlaceReadDto>> GetAllWorkPlacesAsync(CancellationToken cancellationToken)
    {
        var workPlaces = await _repository.GetAllWorkPlacesAsync(cancellationToken);
        return _mapper.Map<IList<WorkPlaceReadDto>>(workPlaces);
    }

    public async Task<Response<WorkPlaceReadDto>> GetWorkPlaceByIdAsync(int id, CancellationToken cancellationToken)
    {
        var workPlace = await _repository.GetWorkPlaceByIdAsync(id, cancellationToken);
        if (workPlace == null)
        {
            return Response<WorkPlaceReadDto>.CreateFailed(System.Net.HttpStatusCode.NotFound, string.Format(ErrorStrings.NotFoundByIdTemplate, id));
        }

        return Response<WorkPlaceReadDto>.CreateSuccess(_mapper.Map<WorkPlaceReadDto>(workPlace));
    }

    public async Task<WorkPlaceReadDto> AddWorkPlaceAsync(WorkPlaceCreateDto workPlaceCreateDto, CancellationToken cancellationToken)
    {
        var workPlace = _mapper.Map<WorkPlace>(workPlaceCreateDto);
        await _repository.CreateWorkPlaceAsync(workPlace, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<WorkPlaceReadDto>(workPlace);
    }

    public async Task<Response> EditWorkPlaceAsync(int id, WorkPlaceUpdateDto workPlaceUpdateDto, CancellationToken cancellationToken)
    {
        var workPlace = await _repository.GetWorkPlaceByIdAsync(id, cancellationToken);
        if (workPlace == null)
        {
            return Response.CreateFailed(System.Net.HttpStatusCode.NotFound, string.Format(ErrorStrings.NotFoundByIdTemplate, id));
        }

        _mapper.Map(workPlaceUpdateDto, workPlace);
        await _repository.SaveChangesAsync(cancellationToken);
        return Response.CreateSuccess(System.Net.HttpStatusCode.NoContent);
    }

    public async Task DeleteWorkPlaceAsync(int id, CancellationToken cancellationToken)
    {
        await _repository.DeleteWorkPlaceAsync(id, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
    }
}
