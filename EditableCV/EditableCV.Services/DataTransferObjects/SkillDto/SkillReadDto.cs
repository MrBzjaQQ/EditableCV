namespace EditableCV.Services.SkillDto;

public sealed class SkillReadDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
}
