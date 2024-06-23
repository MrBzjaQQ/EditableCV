namespace EditableCV.Domain.Models;

public sealed record Project
{
    public int Id { get; private set; }
    public string ProjectName { get; private set; } = string.Empty;
    public string? ProjectUrl { get; private set; }
    public string? RepositoryUrl { get; private set; }
    public StoredFile? Image { get; private set; }

    public void SetImage(StoredFile? file)
    {
        Image = file;
    }
}