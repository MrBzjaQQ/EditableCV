namespace EditableCV.Services.EducationalInstitutionDto;

public sealed record InstitutionReadDto
{
    public int Id { get; init; }
    public string Institution { get; init; } = string.Empty;
    public string? Faculty { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime? EndDate { get; init; }
    public string? Progress { get; init; }
    public bool IsCurrentlyStudying
    {
        get
        {
            return !EndDate.HasValue;
        }
    }
}
