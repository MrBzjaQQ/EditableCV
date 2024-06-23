namespace EditableCV.Services.DataTransferObjects.ProjectDto;

public sealed record ProjectCreateDto
{
    public string ProjectName { get; init; } = string.Empty;
    public string? ProjectUrl { get; init; }
    public string? RepositoryUrl { get; init; }
    public string? ImageName { get; init; }
}