using AutoMapper;
using EditableCV.Dal.CommonInfoData;
using EditableCV.Dal.FileData;
using EditableCV.Services.CommonInfoDto;

namespace EditableCV.Services.CommonInfo;
internal sealed class CommonInfoService(ICommonInfoRepository commonInfoRepository, IFileRepository fileRepository, IMapper mapper) : ICommonInfoService
{
    private readonly ICommonInfoRepository _commonInfoRepository = commonInfoRepository;
    private readonly IFileRepository _fileRepository = fileRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CommonInfoReadDto?> GetCommonInfoAsync(string fileControllerUrl, CancellationToken cancellationToken)
    {
        var commonInfo = await _commonInfoRepository.GetCommonInfoAsync(cancellationToken);
        if (commonInfo == null)
        {
            return null;
        }

        var result = _mapper.Map<CommonInfoReadDto>(commonInfo);
        if (commonInfo.Photo is not null)
        {
            return result with { PhotoUrl = $"{fileControllerUrl}/{commonInfo.Photo.FileName}" };
        }

        return result;
    }

    public async Task PutCommonInfoAsync(CommonInfoCreateDto createDto, CancellationToken cancellationToken)
    {
        var commonInfo = await _commonInfoRepository.GetCommonInfoAsync(cancellationToken);
        if (commonInfo == null)
        {
            var mappedInfo = _mapper.Map<Domain.Models.CommonInfo>(createDto);
            await _commonInfoRepository.AddCommonInfoAsync(mappedInfo, cancellationToken);
            await _commonInfoRepository.SaveChangesAsync(cancellationToken);
            return;
        }

        _mapper.Map(createDto, commonInfo);
        if (string.IsNullOrEmpty(createDto.PhotoFileName))
        {
            await _commonInfoRepository.SaveChangesAsync(cancellationToken);
            return;
        }

        var file = await _fileRepository.GetFileByNameAsync(createDto.PhotoFileName, cancellationToken);
        if (file is null)
        {
            await _commonInfoRepository.SaveChangesAsync(cancellationToken);
            return;
        }

        commonInfo.SetPhoto(file);
        await _commonInfoRepository.SaveChangesAsync(cancellationToken);
    }
}
