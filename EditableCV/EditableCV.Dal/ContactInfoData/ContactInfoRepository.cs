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

        public async Task CreateContactInfoAsync(ContactInfo info, CancellationToken cancellationToken)
        {
            await _context.ContactInfos.AddAsync(info);
        }

        public async Task DeleteContactInfoAsync(int id, CancellationToken cancellationToken)
        {
            var contactInfo = await GetContactInfoAsync(id, cancellationToken);
            if (contactInfo is not null)
            {
                _context.ContactInfos.Remove(contactInfo);
            }
        }

        public async Task<ContactInfo?> GetContactInfoAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.ContactInfos.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<IList<ContactInfo>> GetAllContactInfosAsync(CancellationToken cancellationToken)
        {
            return await _context.ContactInfos.ToListAsync(cancellationToken);
        }
    }
}
