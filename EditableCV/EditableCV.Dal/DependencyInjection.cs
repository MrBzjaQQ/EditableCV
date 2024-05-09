using EditableCV.Dal.CommonInfoData;
using EditableCV.Dal.ContactInfoData;
using EditableCV.Dal.EducationInstitutionData;
using EditableCV.Dal.LandingData;
using EditableCV.Dal.SkillsData;
using EditableCV.Dal.WorkPlaceData;
using Microsoft.Extensions.DependencyInjection;

namespace EditableCV.Dal;
public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IWorkPlacesRepository, WorkPlacesRepository>();
        services.AddScoped<ICommonInfoRepository, CommonInfoRepository>();
        services.AddScoped<IEducationRepository, EducationRepository>();
        services.AddScoped<ISkillsRepository, SkillsRepository>();
        services.AddScoped<IContactInfoRepository, ContactInfoRepository>();
        services.AddScoped<ILandingDataRepository, LandingDataRepository>();

        return services;
    }
}
