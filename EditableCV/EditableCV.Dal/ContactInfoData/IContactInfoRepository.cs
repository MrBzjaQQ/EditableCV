using EditableCV.Domain.Models;

namespace EditableCV.Dal.ContactInfoData
{
    public interface IContactInfoRepository : IRepository
    {
        Task AddContactInfoAsync(ContactInfo info, CancellationToken cancellationToken);
        Task<ContactInfo?> GetContactInfoAsync(CancellationToken cancellationToken);
    }
}
