using System.ComponentModel.DataAnnotations;

namespace EditableCV.Domain.Models;

public sealed record ContactInfo
{
    [Key]
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Value { get; private set; } = string.Empty;
}
