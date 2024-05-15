using EditableCV.Services.CommonInfo;
using EditableCV.Services.ContactInfo;
using EditableCV.Services.Education;
using EditableCV.Services.Files;
using EditableCV.Services.Landing;
using EditableCV.Services.Skills;
using EditableCV.Services.Validators.CommonInfo;
using EditableCV.Services.Validators.ContactInfo;
using EditableCV.Services.Validators.EducationalInstitution;
using EditableCV.Services.Validators.Skill;
using EditableCV.Services.Validators.WorkPlace;
using EditableCV.Services.WorkPlaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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

    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services
            .AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies(), includeInternalTypes: true)
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();

        return services;
    }
}
