using AutoMapper;
using EditableCV.Dal.LandingData;
using EditableCV.Services.LandingDto;

namespace EditableCV.Services.Landing;
internal sealed class LandingService(ILandingDataRepository repository, IMapper mapper) : ILandingService
{
    private readonly ILandingDataRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<LandingReadDto> GetLandingDataAsync(CancellationToken cancellationToken)
    {
        var landingData = await _repository.GetLandingDataAsync(cancellationToken);
        return _mapper.Map<LandingReadDto>(landingData);
    }
}
