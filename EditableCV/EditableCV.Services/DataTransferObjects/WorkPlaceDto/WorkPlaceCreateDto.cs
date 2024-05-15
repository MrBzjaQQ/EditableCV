namespace EditableCV.Services.WorkPlaceDto;

public sealed record WorkPlaceCreateDto
{
    public string CompanyName { get; init; } = string.Empty;
    public string Position { get; init; } = string.Empty;
    public string? Experience { get; init; }
    public DateTime StartWorkingDate { get; init; }
    public DateTime? EndWorkingDate { get; init; }
}
