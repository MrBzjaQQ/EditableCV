using EditableCV.Domain.Models;

namespace EditableCV.Dal.ContactInfoData
{
    public interface IContactInfoRepository : IRepository
    {
        Task CreateContactInfoAsync(ContactInfo info, CancellationToken cancellationToken);
        Task DeleteContactInfoAsync(int id, CancellationToken cancellationToken);
        Task<ContactInfo?> GetContactInfoAsync(int id, CancellationToken cancellationToken);
        Task<IList<ContactInfo>> GetAllContactInfosAsync(CancellationToken cancellationToken);
    }
}
