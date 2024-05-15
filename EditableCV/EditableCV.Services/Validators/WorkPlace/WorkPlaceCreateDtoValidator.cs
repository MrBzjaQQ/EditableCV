using EditableCV.Services.WorkPlaceDto;
using FluentValidation;

namespace EditableCV.Services.Validators.WorkPlace;
internal sealed class WorkPlaceCreateDtoValidator: AbstractValidator<WorkPlaceCreateDto>
{
    public WorkPlaceCreateDtoValidator()
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
