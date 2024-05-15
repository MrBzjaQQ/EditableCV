using EditableCV.Services.EducationalInstitutionDto;
using FluentValidation;

namespace EditableCV.Services.Validators.EducationalInstitution;
internal sealed class InstitutionCreateDtoValidator: AbstractValidator<InstitutionCreateDto>
{
    public InstitutionCreateDtoValidator()
    {
        RuleFor(x => x.Institution).NotEmpty();
        RuleFor(x => x.StartDate).NotEmpty();
    }
}
