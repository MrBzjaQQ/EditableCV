namespace EditableCV.Services.DataTransferObjects.ProjectDto;

public sealed record ProjectUpdateDto
{
    public string ProjectName { get; init; } = string.Empty;
    public string? ProjectUrl { get; init; }
    public string? RepositoryUrl { get; init; }
    public string? ImageName { get; init; }
}