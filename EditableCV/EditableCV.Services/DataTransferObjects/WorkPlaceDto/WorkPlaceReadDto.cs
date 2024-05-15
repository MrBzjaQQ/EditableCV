namespace EditableCV.Services.WorkPlaceDto;

public sealed record WorkPlaceReadDto
{
    public int Id { get; init; }
    public string CompanyName { get; init; } = string.Empty;
    public string Position { get; init; } = string.Empty;
    public string? Experience { get; init; }
    public DateTime StartWorkingDate { get; init; }
    public bool IsCurrentlyWorking
    {
        get
        {
            return !EndWorkingDate.HasValue;
        }
    }
    public DateTime? EndWorkingDate { get; init; }
}
