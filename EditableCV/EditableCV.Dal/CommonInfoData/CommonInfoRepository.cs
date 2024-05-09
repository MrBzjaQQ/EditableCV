using EditableCV.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EditableCV.Dal.CommonInfoData
{
    public class CommonInfoRepository : RepositoryBase, ICommonInfoRepository
    {
        private readonly IResumeContext _context;

        public CommonInfoRepository(IResumeContext context)
            : base(context)
        {
            _context = context;
        }
        public Task<CommonInfo?> GetCommonInfoAsync(CancellationToken cancellationToken)
        {
            return _context.CommonInfos.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task AddCommonInfoAsync(CommonInfo info, CancellationToken cancellationToken)
        {
            var commonInfo = await GetCommonInfoAsync(cancellationToken);
            if (commonInfo == null)
            {
                _context.CommonInfos.Add(info);
            }
        }
    }
}
