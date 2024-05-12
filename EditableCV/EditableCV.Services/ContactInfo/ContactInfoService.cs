using AutoMapper;
using EditableCV.Dal.ContactInfoData;
using EditableCV.Resources;
using EditableCV.Services.ContactInfoDto;
using EditableCV.Services.DataTransferObjects.ContactInfoDto;
using EditableCV.Services.Shared;

namespace EditableCV.Services.ContactInfo;
internal sealed class ContactInfoService(IContactInfoRepository repository, IMapper mapper): IContactInfoService
{
    private readonly IContactInfoRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<IList<ContactInfoReadDto>> GetAllContactInfosAsync(CancellationToken cancellationToken)
    {
        var contactInfos = await _repository.GetAllContactInfosAsync(cancellationToken);
        return _mapper.Map<IList<ContactInfoReadDto>>(contactInfos);
    }

    public async Task<Response<ContactInfoReadDto>> GetContactInfoByIdAsync(int id, CancellationToken cancellationToken)
    {
        var contactInfo = await _repository.GetContactInfoAsync(id, cancellationToken);
        if (contactInfo is null)
        {
            return Response<ContactInfoReadDto>.CreateFailed(System.Net.HttpStatusCode.NotFound, string.Format(ErrorStrings.NotFoundByIdTemplate, id));
        }

        return Response<ContactInfoReadDto>.CreateSuccess(_mapper.Map<ContactInfoReadDto>(contactInfo));
    }

    public async Task<ContactInfoReadDto> AddContactInfoAsync(ContactInfoCreateDto contactInfoUpdateDto, CancellationToken cancellationToken)
    {
        var contactInfo = _mapper.Map<Domain.Models.ContactInfo>(contactInfoUpdateDto);
        await _repository.CreateContactInfoAsync(contactInfo, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<ContactInfoReadDto>(contactInfo);
    }

    public async Task<Response> EditContactInfoAsync(int id, ContactInfoUpdateDto contactInfoUpdateDto, CancellationToken cancellationToken)
    {
        var contactInfo = await _repository.GetContactInfoAsync(id, cancellationToken);
        if (contactInfo is null)
        {
            return Response.CreateFailed(System.Net.HttpStatusCode.NotFound, string.Format(ErrorStrings.NotFoundByIdTemplate, id));
        }

        _mapper.Map(contactInfoUpdateDto, contactInfo);
        await _repository.SaveChangesAsync(cancellationToken);
        return Response.CreateSuccess(System.Net.HttpStatusCode.NoContent);
    }

    public async Task DeleteContactInfoAsync(int id, CancellationToken cancellationToken)
    {
        await _repository.DeleteContactInfoAsync(id, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
    }
}
