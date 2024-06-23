using EditableCV.Services.DataTransferObjects.LandingDto;

namespace EditableCV.Services.Landing;
public interface ILandingService
{
    Task<LandingReadDto> GetLandingDataAsync(string photoControllerUrl, CancellationToken cancellationToken);
}
