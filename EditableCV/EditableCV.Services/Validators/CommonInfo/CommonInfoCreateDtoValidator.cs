using EditableCV.Services.CommonInfoDto;
using FluentValidation;

namespace EditableCV.Services.Validators.CommonInfo;
internal sealed class CommonInfoCreateDtoValidator: AbstractValidator<CommonInfoCreateDto>
{
    public CommonInfoCreateDtoValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.DateOfBirth).NotEmpty();
    }
}
