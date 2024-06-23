namespace EditableCV.Services.DataTransferObjects.ProjectDto;

public sealed record ProjectReadDto
{
    public int Id { get; init; }
    public string ProjectName { get; init; } = string.Empty;
    public string? ProjectUrl { get; init; }
    public string? RepositoryUrl { get; init; }
    public string? ImageUrl { get; init; }
}