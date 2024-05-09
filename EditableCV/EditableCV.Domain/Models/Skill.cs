using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EditableCV.Domain.Models
{
    public record Skill
    {
        public Skill() { }
        public Skill(Skill skill)
        {
            Id = skill.Id;
            Name = skill.Name;
            Description = skill.Description;
        }
        [Key]
        public int Id { get; init; }
        [Required]
        public string Name { get; init; }
        public string Description { get; init; }
        [NotMapped]
        public bool IsValid
        {
            get
            {
                bool isValid = true;
                if (Name == null || Name == string.Empty)
                {
                    isValid = false;
                }
                return isValid;
            }
        }
    }
}
