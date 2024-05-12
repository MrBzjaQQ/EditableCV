using EditableCV.Services.ContactInfoDto;
using EditableCV.Services.DataTransferObjects.ContactInfoDto;
using EditableCV.Services.Shared;

namespace EditableCV.Services.ContactInfo;
public interface IContactInfoService
{
    Task<IList<ContactInfoReadDto>> GetAllContactInfosAsync(CancellationToken cancellationToken);
    Task<Response<ContactInfoReadDto>> GetContactInfoByIdAsync(int id, CancellationToken cancellationToken);
    Task<ContactInfoReadDto> AddContactInfoAsync(ContactInfoCreateDto contactInfoUpdateDto, CancellationToken cancellationToken);
    Task<Response> EditContactInfoAsync(int id, ContactInfoUpdateDto contactInfoUpdateDto, CancellationToken cancellationToken);
    Task DeleteContactInfoAsync(int id, CancellationToken cancellationToken);
}
