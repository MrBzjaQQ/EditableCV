using EditableCV.Domain.Models;

namespace EditableCV.Dal.WorkPlaceData
{
    public interface IWorkPlacesRepository : IRepository
    {
        Task<IList<WorkPlace>> GetAllWorkPlacesAsync(CancellationToken cancellationToken);
        Task<WorkPlace?> GetWorkPlaceByIdAsync(int id, CancellationToken cancellationToken);
        Task CreateWorkPlaceAsync(WorkPlace place, CancellationToken cancellationToken);
        Task DeleteWorkPlaceAsync(int id, CancellationToken cancellationToken);
    }
}
