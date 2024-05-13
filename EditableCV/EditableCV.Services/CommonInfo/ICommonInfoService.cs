using EditableCV.Services.CommonInfoDto;

namespace EditableCV.Services.CommonInfo;
public interface ICommonInfoService
{
    Task<CommonInfoReadDto?> GetCommonInfoAsync(string photoControllerUrl, CancellationToken cancellationToken);
    Task PutCommonInfoAsync(CommonInfoCreateDto createDto, CancellationToken cancellationToken);
}
