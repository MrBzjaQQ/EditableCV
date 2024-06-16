namespace EditableCV.Domain.Models;

public sealed record CommonInfo
{
    public int Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string? PatronymicName { get; private set; } = string.Empty;
    public DateTime DateOfBirth { get; private set; }
    public StoredFile? Photo { get; private set; }
    public decimal Salary { get; private set; }

    public void SetPhoto(StoredFile? photo)
    {
        Photo = photo;
    }
}
