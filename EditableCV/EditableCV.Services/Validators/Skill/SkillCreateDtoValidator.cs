using EditableCV.Services.SkillDto;
using FluentValidation;

namespace EditableCV.Services.Validators.Skill;
internal sealed class SkillCreateDtoValidator: AbstractValidator<SkillCreateDto>
{
    public SkillCreateDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
