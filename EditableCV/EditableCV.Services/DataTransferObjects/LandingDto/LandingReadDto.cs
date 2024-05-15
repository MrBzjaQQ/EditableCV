using EditableCV.Services.CommonInfoDto;
using EditableCV.Services.ContactInfoDto;
using EditableCV.Services.EducationalInstitutionDto;
using EditableCV.Services.SkillDto;
using EditableCV.Services.WorkPlaceDto;

namespace EditableCV.Services.LandingDto;

public sealed record LandingReadDto
{
    public CommonInfoReadDto? CommonInfo { get; init; }
    public IList<ContactInfoReadDto> ContactInfo { get; init; } = Array.Empty<ContactInfoReadDto>();
    public IList<WorkPlaceReadDto> WorkPlaces { get; init; } = Array.Empty<WorkPlaceReadDto>();
    public IList<InstitutionReadDto> Education { get; init; } = Array.Empty<InstitutionReadDto>();
    public IList<SkillReadDto> Skills { get; init; } = Array.Empty<SkillReadDto>();
}
