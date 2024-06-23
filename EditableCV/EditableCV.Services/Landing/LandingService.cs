using AutoMapper;
using EditableCV.Services.CommonInfo;
using EditableCV.Services.ContactInfo;
using EditableCV.Services.DataTransferObjects.LandingDto;
using EditableCV.Services.Education;
using EditableCV.Services.Projects;
using EditableCV.Services.Skills;
using EditableCV.Services.WorkPlaces;

namespace EditableCV.Services.Landing;
internal sealed class LandingService(
    ICommonInfoService commonInfoService,
    IContactInfoService contactInfoService,
    IWorkPlacesService workPlacesService,
    ISkillsService skillsService,
    IEducationService educationService,
    IProjectsService projectsService) : ILandingService
{

    public async Task<LandingReadDto> GetLandingDataAsync(string fileControllerUrl, CancellationToken cancellationToken)
    {
        return new LandingReadDto
        {
            CommonInfo = await commonInfoService.GetCommonInfoAsync(fileControllerUrl, cancellationToken),
            ContactInfo = await contactInfoService.GetAllContactInfosAsync(cancellationToken),
            Education = await educationService.GetAllInstitutionsAsync(cancellationToken),
            Skills = await skillsService.GetSkillsAsync(cancellationToken),
            WorkPlaces = await workPlacesService.GetAllWorkPlacesAsync(fileControllerUrl, cancellationToken),
            Projects = await projectsService.GetAllProjectsAsync(fileControllerUrl, cancellationToken)
        };
    }
}
