using EditableCV.Dal.CommonInfoData;
using EditableCV.Dal.ContactInfoData;
using EditableCV.Dal.EducationInstitutionData;
using EditableCV.Dal.FileData;
using EditableCV.Dal.ProjectData;
using EditableCV.Dal.SkillsData;
using EditableCV.Dal.WorkPlaceData;
using Microsoft.Extensions.DependencyInjection;

namespace EditableCV.Dal;
public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IWorkPlacesRepository, WorkPlacesRepository>();
        services.AddTransient<ICommonInfoRepository, CommonInfoRepository>();
        services.AddTransient<IEducationRepository, EducationRepository>();
        services.AddTransient<ISkillsRepository, SkillsRepository>();
        services.AddTransient<IContactInfoRepository, ContactInfoRepository>();
        services.AddTransient<IFileRepository, FileRepository>();
        services.AddTransient<IProjectsRepository, ProjectsRepository>();

        return services;
    }
}
