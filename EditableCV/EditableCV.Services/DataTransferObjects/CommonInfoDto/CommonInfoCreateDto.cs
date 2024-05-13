using System.ComponentModel.DataAnnotations;

namespace EditableCV.Services.CommonInfoDto
{
    public sealed record CommonInfoCreateDto
    {
        [Required]
        public string FirstName { get; init; } = string.Empty;
        [Required]
        public string LastName { get; init; } = string.Empty;
        public string PatronymicName { get; init; } = string.Empty;
        [Required]
        public DateTime DateOfBirth { get; init; }
        public string? PhotoFileName { get; init; } = string.Empty;
    }
}
