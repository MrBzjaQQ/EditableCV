using System.ComponentModel.DataAnnotations.Schema;

namespace EditableCV.Domain.Models;

public sealed record WorkPlace
{
    public int Id { get; private set; }
    public string CompanyName { get; private set; } = 
        null!;
    public string Position { get; private set; } = 
        null!;
    public string? Experience { get; private set; }
    public DateTime StartWorkingDate { get; private set; }
    public DateTime? EndWorkingDate { get; private set; }
    public string? WebSite { get; private set; }
    public StoredFile? Logo { get; private set; }

    [NotMapped]
    public bool IsValid
    {
        get
        {
            bool isValid = true;
            if (CompanyName == null || CompanyName == string.Empty)
            {
                isValid = false;
            }
            if (Position == null || Position == string.Empty)
            {
                isValid = false;
            }
            if (DateTime.MinValue.CompareTo(StartWorkingDate) == 0)
            {
                isValid = false;
            }
            if (DateTime.MinValue.CompareTo(EndWorkingDate) == 0)
            {
                isValid = false;
            }
            if (EndWorkingDate.HasValue && EndWorkingDate.Value.CompareTo(StartWorkingDate) < 0)
            {
                isValid = false;
            }
            return isValid;
        }
    }

    public void SetLogo(StoredFile? logo)
    {
        Logo = logo;
    }
}

