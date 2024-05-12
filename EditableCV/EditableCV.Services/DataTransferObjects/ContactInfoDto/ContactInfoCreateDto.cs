namespace EditableCV.Services.DataTransferObjects.ContactInfoDto;
public sealed record ContactInfoCreateDto
{
    public string Name { get; init; } = string.Empty;
    public string Value { get; init; } = string.Empty;
}
