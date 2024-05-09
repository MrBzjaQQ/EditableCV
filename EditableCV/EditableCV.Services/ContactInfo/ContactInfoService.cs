using AutoMapper;
using EditableCV.Dal.ContactInfoData;
using EditableCV.Services.ContactInfoDto;

namespace EditableCV.Services.ContactInfo;
internal sealed class ContactInfoService(IContactInfoRepository repository, IMapper mapper): IContactInfoService
{
    private readonly IContactInfoRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<ContactInfoReadDto?> GetContactInfoAsync(CancellationToken cancellationToken)
    {
        var info = await _repository.GetContactInfoAsync(cancellationToken);
        if (info == null)
        {
            return null;
        }

        return _mapper.Map<ContactInfoReadDto>(info);
    }

    public async Task PutContactInfoAsync(ContactInfoUpdateDto updateInfoDto, CancellationToken cancellationToken)
    {
        var info = await GetContactInfoAsync(cancellationToken);
        if (info == null)
        {
            var mappedInfo = _mapper.Map<Domain.Models.ContactInfo>(updateInfoDto);
            await _repository.AddContactInfoAsync(mappedInfo, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
