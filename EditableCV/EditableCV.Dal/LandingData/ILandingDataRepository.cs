using EditableCV.Domain.Models;

namespace EditableCV.Dal.LandingData
{
    public interface ILandingDataRepository
    {
        Task<LandingDataModel> GetLandingDataAsync(CancellationToken cancellationToken);
    }
}
