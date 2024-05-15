using EditableCV.Services.WorkPlaceDto;
using FluentValidation;

namespace EditableCV.Services.Validators.WorkPlace;
internal sealed class WorkPlaceUpdateDtoValidator : AbstractValidator<WorkPlaceUpdateDto>
{
    public WorkPlaceUpdateDtoValidator()
    {
        RuleFor(x => x.CompanyName)
            .NotEmpty()
            .MaximumLength(250);

        RuleFor(x => x.Position)
            .NotEmpty()
            .MaximumLength(250);

        RuleFor(x => x.StartWorkingDate).NotEmpty();
    }
}
