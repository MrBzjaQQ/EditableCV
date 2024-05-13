using System.ComponentModel.DataAnnotations;

namespace EditableCV.Services.DataTransferObjects.FileDto;
public sealed record FileReadDto
{
    public int Id { get; init; }

    [Required]
    public string FileName { get; init; } = string.Empty;
}
