namespace EditableCV.Domain.Models;

public sealed record ContactInfo
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Value { get; private set; } = string.Empty;
}
