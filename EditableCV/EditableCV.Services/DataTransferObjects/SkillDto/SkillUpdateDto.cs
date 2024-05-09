using System.ComponentModel.DataAnnotations;

namespace EditableCV.Services.SkillDto
{
    public class SkillUpdateDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
