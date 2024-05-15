using EditableCV.Services.ContactInfoDto;
using FluentValidation;

namespace EditableCV.Services.Validators.ContactInfo;
internal sealed class ContactInfoUpdateDtoValidator: AbstractValidator<ContactInfoUpdateDto>
{
    public ContactInfoUpdateDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Value).NotEmpty();
    }
}
