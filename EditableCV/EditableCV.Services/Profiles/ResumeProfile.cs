using AutoMapper;
using EditableCV.Domain.Models;
using EditableCV.Services.CommonInfoDto;
using EditableCV.Services.ContactInfoDto;
using EditableCV.Services.DataTransferObjects.ContactInfoDto;
using EditableCV.Services.DataTransferObjects.FileDto;
using EditableCV.Services.EducationalInstitutionDto;
using EditableCV.Services.SkillDto;
using EditableCV.Services.WorkPlaceDto;

namespace EditableCV.Server.Profiles
{
    public class ResumeProfile : Profile
    {
        public ResumeProfile()
        {
            CreateWorkPlaceMapping();
            CreateCommonInfoMapping();
            CreateEducationMapping();
            CreateSkillMapping();
            CreateContactInfoMapping();
            CreateImageMapping();
        }

        private void CreateWorkPlaceMapping()
        {
            CreateMap<WorkPlace, WorkPlaceReadDto>()
                .ForMember(dest => dest.LogoUrl, config => config.Ignore());
            CreateMap<WorkPlaceCreateDto, WorkPlace>()
                .ForMember(dest => dest.Logo, config => config.Ignore());
            CreateMap<WorkPlaceUpdateDto, WorkPlace>()
                .ForMember(dest => dest.Logo, config => config.Ignore());
            CreateMap<WorkPlace, WorkPlaceUpdateDto>();
        }

        private void CreateCommonInfoMapping()
        {
            CreateMap<CommonInfoCreateDto, CommonInfo>();
            CreateMap<CommonInfo, CommonInfoReadDto>()
              .ForMember(
                dto => dto.Age,
                info => info.MapFrom(commonInfo => GetAgeByDateOfBirth(commonInfo.DateOfBirth))
              )
              .ForMember(
                dto => dto.PhotoUrl,
                config => config.Ignore());
        }

        private void CreateEducationMapping()
        {
            CreateMap<EducationalInstitution, InstitutionReadDto>();
            CreateMap<InstitutionCreateDto, EducationalInstitution>();
            CreateMap<InstitutionUpdateDto, EducationalInstitution>();
            CreateMap<EducationalInstitution, InstitutionUpdateDto>();
        }

        private void CreateSkillMapping()
        {
            CreateMap<Skill, SkillReadDto>();
            CreateMap<SkillCreateDto, Skill>();
            CreateMap<SkillUpdateDto, Skill>();
            CreateMap<Skill, SkillUpdateDto>();
        }

        private void CreateContactInfoMapping()
        {
            CreateMap<ContactInfo, ContactInfoReadDto>();
            CreateMap<ContactInfoUpdateDto, ContactInfo>();
            CreateMap<ContactInfoCreateDto, ContactInfo>();
        }

        private void CreateImageMapping()
        {
            CreateMap<Domain.Models.StoredFile, FileReadDto>();
        }

        private int GetAgeByDateOfBirth(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
