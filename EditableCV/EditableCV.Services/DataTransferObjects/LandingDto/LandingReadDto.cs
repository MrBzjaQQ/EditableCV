using EditableCV.Services.CommonInfoDto;
using EditableCV.Services.ContactInfoDto;
using EditableCV.Services.EducationalInstitutionDto;
using EditableCV.Services.SkillDto;
using EditableCV.Services.WorkPlaceDto;

namespace EditableCV.Services.LandingDto
{
    public class LandingReadDto
    {
        public CommonInfoReadLandingDto CommonInfo { get; set; }
        public ContactInfoReadDto ContactInfo { get; set; }
        public IEnumerable<WorkPlaceReadDto> WorkPlaces { get; set; }
        public IEnumerable<InstitutionReadDto> Education { get; set; }
        public IEnumerable<SkillReadDto> Skills { get; set; }
    }
}
