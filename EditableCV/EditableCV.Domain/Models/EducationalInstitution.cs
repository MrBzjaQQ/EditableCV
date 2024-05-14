using System.ComponentModel.DataAnnotations.Schema;

namespace EditableCV.Domain.Models;

public sealed record EducationalInstitution
{
    public int Id { get; private set; }
    public string Institution { get; private set; } = null!;
    public string Faculty { get; private set; } = null!;
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public string? Progress { get; private set; }

    [NotMapped]
    public bool IsValid
    {
        get
        {
            bool isValid = true;
            if (Institution == null || Institution == string.Empty)
            {
                isValid = false;
            }
            if (DateTime.MinValue.CompareTo(StartDate) == 0)
            {
                isValid = false;
            }
            if (DateTime.MinValue.CompareTo(EndDate) == 0)
            {
                isValid = false;
            }
            if (EndDate.HasValue && EndDate.Value.CompareTo(StartDate) < 0)
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
