namespace EditableCV.Services.SkillDto;

public sealed record SkillUpdateDto
{
    public string Name { get; init; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
}
