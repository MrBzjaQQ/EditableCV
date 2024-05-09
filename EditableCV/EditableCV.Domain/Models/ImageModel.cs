using System.ComponentModel.DataAnnotations;

namespace EditableCV.Domain.Models
{
    public record ImageModel
    {
        [Key]
        public int Id { get; init; }
        [Required]
        public string Name { get; init; }
        [Required]
        public byte[] Data { get; init; }
    }
}
