using EditableCV.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EditableCV.Dal.ContactInfoData
{
    public class ContactInfoRepository : RepositoryBase, IContactInfoRepository
    {
        private readonly IResumeContext _context;

        public ContactInfoRepository(IResumeContext context): base(context)
        {
            _context = context;
        }

        public async Task AddContactInfoAsync(ContactInfo info, CancellationToken cancellationToken)
        {
            var currInfo = await GetContactInfoAsync(cancellationToken);
            if (currInfo == null)
            {
                _context.ContactInfos.Add(info);
            }
        }

        public async Task<ContactInfo?> GetContactInfoAsync(CancellationToken cancellationToken)
        {
            return await _context.ContactInfos.FirstOrDefaultAsync(cancellationToken);
        }
    }
}
