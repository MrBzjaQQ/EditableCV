namespace EditableCV.Services.SkillDto;

public sealed record SkillCreateDto
{
    public string Name { get; init; } = string.Empty;
    public string? Description { get; set; }
}
