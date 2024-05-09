using EditableCV.Domain.Models;

namespace EditableCV.Dal.CommonInfoData
{
    public interface ICommonInfoRepository : IRepository
    {
        Task<CommonInfo?> GetCommonInfoAsync(CancellationToken cancellationToken);
        Task AddCommonInfoAsync(CommonInfo info, CancellationToken cancellationToken);
    }
}
