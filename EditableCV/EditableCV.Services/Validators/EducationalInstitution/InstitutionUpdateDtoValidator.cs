using EditableCV.Services.EducationalInstitutionDto;
using FluentValidation;

namespace EditableCV.Services.Validators.EducationalInstitution;
internal sealed class InstitutionUpdateDtoValidator: AbstractValidator<InstitutionUpdateDto>
{
    public InstitutionUpdateDtoValidator()
    {
        RuleFor(x => x.Institution).NotEmpty();
        RuleFor(x => x.StartDate).NotEmpty();
    }
}
