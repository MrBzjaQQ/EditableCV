using EditableCV.Services.Shared;
using EditableCV.Services.WorkPlaceDto;

namespace EditableCV.Services.WorkPlaces;
public interface IWorkPlacesService
{
    Task<IList<WorkPlaceReadDto>> GetAllWorkPlacesAsync(string fileControllerUrl, CancellationToken cancellationToken);
    Task<Response<WorkPlaceReadDto>> GetWorkPlaceByIdAsync(int id, string fileControllerUrl, CancellationToken cancellationToken);
    Task<WorkPlaceReadDto> AddWorkPlaceAsync(WorkPlaceCreateDto workPlaceCreateDto, string fileControllerUrl, CancellationToken cancellationToken);
    Task<Response> EditWorkPlaceAsync(int id, WorkPlaceUpdateDto workPlaceUpdateDto, CancellationToken cancellationToken);
    Task DeleteWorkPlaceAsync(int id, CancellationToken cancellationToken);
}
