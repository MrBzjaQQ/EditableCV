using EditableCV.Services.SkillDto;
using FluentValidation;

namespace EditableCV.Services.Validators.Skill;
internal sealed class SkillUpdateDtoValidator: AbstractValidator<SkillUpdateDto>
{
    public SkillUpdateDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
