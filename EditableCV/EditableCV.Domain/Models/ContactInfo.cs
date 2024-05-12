using System.ComponentModel.DataAnnotations;

namespace EditableCV.Domain.Models
{
    public record ContactInfo
    {
        [Key]
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Value { get; init; } = string.Empty;
    }
}
