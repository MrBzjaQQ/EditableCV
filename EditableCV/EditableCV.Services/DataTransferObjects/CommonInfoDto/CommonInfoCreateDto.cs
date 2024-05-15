namespace EditableCV.Services.CommonInfoDto;
public sealed record CommonInfoCreateDto
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string? PatronymicName { get; init; }
    public DateTime DateOfBirth { get; init; }
    public string? PhotoFileName { get; init; }
}
