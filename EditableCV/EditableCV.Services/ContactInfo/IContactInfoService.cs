using EditableCV.Services.ContactInfoDto;

namespace EditableCV.Services.ContactInfo;
public interface IContactInfoService
{
    Task<ContactInfoReadDto?> GetContactInfoAsync(CancellationToken cancellationToken);
    Task PutContactInfoAsync(ContactInfoUpdateDto updateInfoDto, CancellationToken cancellationToken);
}
