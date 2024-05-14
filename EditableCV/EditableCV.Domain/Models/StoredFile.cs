namespace EditableCV.Domain.Models;

public sealed record StoredFile
{
    public StoredFile() {}

    public StoredFile(string fileName)
    {
        FileName = fileName;
    }

    public int Id { get; private set; }
    public string FileName { get; private set; } = null!;
}