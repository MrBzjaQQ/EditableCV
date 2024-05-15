using EditableCV.Services.DataTransferObjects.ContactInfoDto;
using FluentValidation;

namespace EditableCV.Services.Validators.ContactInfo;
internal sealed class ContactInfoCreateDtoValidator: AbstractValidator<ContactInfoCreateDto>
{
    public ContactInfoCreateDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Value).NotEmpty();
    }
}
