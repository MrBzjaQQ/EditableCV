using System.ComponentModel.DataAnnotations;

namespace EditableCV_backend.DataTransferObjects.SkillDto
{
    public class SkillUpdateDto
  {
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
  }
}
