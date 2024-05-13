using AutoMapper;
using EditableCV.Services.CommonInfo;
using EditableCV.Services.ContactInfo;
using EditableCV.Services.Education;
using EditableCV.Services.LandingDto;
using EditableCV.Services.Skills;
using EditableCV.Services.WorkPlaces;

namespace EditableCV.Services.Landing;
internal sealed class LandingService(
    ICommonInfoService commonInfoService,
    IContactInfoService contactInfoService,
    IWorkPlacesService workPlacesService,
    ISkillsService skillsService,
    IEducationService educationService,
    IMapper mapper) : ILandingService
{
    private readonly ICommonInfoService _commonInfoService = commonInfoService;
    private readonly IContactInfoService _contactInfoService = contactInfoService;
    private readonly IWorkPlacesService _workPlacesService = workPlacesService;
    private readonly ISkillsService _skillsService = skillsService;
    private readonly IEducationService _educationService = educationService;
    private readonly IMapper _mapper = mapper;

    public async Task<LandingReadDto> GetLandingDataAsync(string photoControllerUrl, CancellationToken cancellationToken)
    {
        return new LandingReadDto
        {
            CommonInfo = await _commonInfoService.GetCommonInfoAsync(photoControllerUrl, cancellationToken),
            ContactInfo = await _contactInfoService.GetAllContactInfosAsync(cancellationToken),
            Education = await _educationService.GetAllInstitutionsAsync(cancellationToken),
            Skills = await _skillsService.GetSkillsAsync(cancellationToken),
            WorkPlaces = await _workPlacesService.GetAllWorkPlacesAsync(cancellationToken),
        };
    }
}
