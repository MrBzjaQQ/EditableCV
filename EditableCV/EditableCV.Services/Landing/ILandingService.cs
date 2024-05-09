using EditableCV.Services.LandingDto;

namespace EditableCV.Services.Landing;
public interface ILandingService
{
    Task<LandingReadDto> GetLandingDataAsync(CancellationToken cancellationToken);
}
