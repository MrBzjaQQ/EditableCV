using EditableCV.Services.CommonInfo;
using EditableCV.Services.ContactInfo;
using EditableCV.Services.Education;
using EditableCV.Services.Files;
using EditableCV.Services.Landing;
using EditableCV.Services.Skills;
using EditableCV.Services.WorkPlaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EditableCV.Services;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<ICommonInfoService, CommonInfoService>();
        services.AddTransient<IContactInfoService, ContactInfoService>();
        services.AddTransient<IEducationService, EducationService>();
        services.AddTransient<ISkillsService, SkillsService>();
        services.AddTransient<IWorkPlacesService, WorkPlacesService>();
        services.AddTransient<ILandingService, LandingService>();
        services.AddTransient<IFilesService, FilesService>();

        return services;
    }
}
