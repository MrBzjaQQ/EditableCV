using AutoMapper;
using EditableCV.Dal.CommonInfoData;
using EditableCV.Services.CommonInfoDto;

namespace EditableCV.Services.CommonInfo;
internal sealed class CommonInfoService(ICommonInfoRepository repository, IMapper mapper) : ICommonInfoService
{
    private readonly ICommonInfoRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<CommonInfoReadDto?> GetCommonInfoAsync(CancellationToken cancellationToken)
    {
        var commonInfo = await _repository.GetCommonInfoAsync(cancellationToken);
        if (commonInfo == null)
        {
            return null;
        }

        return _mapper.Map<CommonInfoReadDto>(commonInfo);
    }

    public async Task PutCommonInfoAsync(CommonInfoCreateDto createDto, CancellationToken cancellationToken)
    {
        var commonInfo = await _repository.GetCommonInfoAsync(cancellationToken);
        if (commonInfo == null)
        {
            var mappedInfo = _mapper.Map<Domain.Models.CommonInfo>(createDto);
            await _repository.AddCommonInfoAsync(mappedInfo, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return;
        }

        _mapper.Map(createDto, commonInfo);
        await _repository.SaveChangesAsync(cancellationToken);
    }
}
