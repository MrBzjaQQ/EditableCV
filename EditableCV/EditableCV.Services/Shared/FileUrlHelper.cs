namespace EditableCV.Services.Shared;
public static class FileUrlHelper
{
    public static string GetFileUrl(string fileControllerUrl, string fileName)
    {
        return $"{fileControllerUrl}/{fileName}";
    }
}
