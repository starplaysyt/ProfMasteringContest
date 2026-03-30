namespace ProfMasteringProject.Settings;

public class FileStorageSettings
{
    public string BasePath { get; set; } = "Storage/uploads";
    public int MaxFileSizeMB { get; set; } = 10;
    public string[] AllowedExtensions { get; set; } = Array.Empty<string>();
    
    public long MaxFileSizeBytes => MaxFileSizeMB * 1024 * 1024;
}