using System.ComponentModel.DataAnnotations;

namespace EditableCV.Domain.Models
{
    public sealed record FileModel
    {
        [Key]
        public int Id { get; init; }
        public string FileName { get; init; } = string.Empty;
    }
}
