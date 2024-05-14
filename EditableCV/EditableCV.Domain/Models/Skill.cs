using System.ComponentModel.DataAnnotations.Schema;

namespace EditableCV.Domain.Models;

public sealed record Skill
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }

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

