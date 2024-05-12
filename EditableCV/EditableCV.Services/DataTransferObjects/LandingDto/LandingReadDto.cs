using EditableCV.Services.CommonInfoDto;
using EditableCV.Services.ContactInfoDto;
using EditableCV.Services.EducationalInstitutionDto;
using EditableCV.Services.SkillDto;
using EditableCV.Services.WorkPlaceDto;

namespace EditableCV.Services.LandingDto
{
    public sealed record LandingReadDto
    {
        public CommonInfoReadLandingDto? CommonInfo { get; set; }
        public IList<ContactInfoReadDto> ContactInfo { get; set; } = Array.Empty<ContactInfoReadDto>();
        public IList<WorkPlaceReadDto> WorkPlaces { get; set; } = Array.Empty<WorkPlaceReadDto>();
        public IList<InstitutionReadDto> Education { get; set; } = Array.Empty<InstitutionReadDto>();
        public IList<SkillReadDto> Skills { get; set; } = Array.Empty<SkillReadDto>();
    }
}
