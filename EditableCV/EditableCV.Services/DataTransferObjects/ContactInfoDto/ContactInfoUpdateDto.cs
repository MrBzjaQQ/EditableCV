namespace EditableCV.Services.ContactInfoDto;

public sealed record ContactInfoUpdateDto
{
    public string Name { get; init; } = string.Empty;
    public string Value { get; init; } = string.Empty;
}
