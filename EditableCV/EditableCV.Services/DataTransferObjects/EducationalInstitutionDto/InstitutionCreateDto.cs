namespace EditableCV.Services.EducationalInstitutionDto;

public sealed record InstitutionCreateDto
{
    public string Institution { get; init; } = string.Empty;
    public string? Faculty { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime? EndDate { get; init; }
    public string? Progress { get; init; }
}
