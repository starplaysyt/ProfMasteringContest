using Microsoft.Extensions.Options;
using ProfMasteringProject.Settings;

namespace ProfMasteringProject.Services;

public interface IFileService
{
    Task<string> SaveFileAsync(IFormFile file, string folder);
    void DeleteFile(string filePath);
    string GetFullPath(string relativePath);
    bool FileExists(string relativePath);
}

public partial class FileService : IFileService
{
    private readonly FileStorageSettings _settings;
    private readonly IWebHostEnvironment _env;
    private readonly ILogger<FileService> _logger;

    public FileService(
        IOptions<FileStorageSettings> settings,
        IWebHostEnvironment env,
        ILogger<FileService> logger)
    {
        _settings = settings.Value;
        _env = env;
        _logger = logger;
    }

    public async Task<string> SaveFileAsync(IFormFile file, string folder)
    {
        ValidateFile(file);
        
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        var uniqueName = $"{Guid.NewGuid():N}{extension}";
        
        var folderPath = Path.Combine(_env.ContentRootPath, _settings.BasePath, folder);
        Directory.CreateDirectory(folderPath);

        var fullPath = Path.Combine(folderPath, uniqueName);
        
        await using var stream = new FileStream(fullPath, FileMode.Create);
        await file.CopyToAsync(stream);

        LogFileSavedPath(fullPath);
        
        return Path.Combine(folder, uniqueName);
    }

    public void DeleteFile(string relativePath)
    {
        if (string.IsNullOrEmpty(relativePath)) return;

        var fullPath = GetFullPath(relativePath);
        
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
            _logger.LogInformation("File deleted: {Path}", fullPath);
        }
    }

    public string GetFullPath(string relativePath)
    {
        return Path.Combine(_env.ContentRootPath, _settings.BasePath, relativePath);
    }

    public bool FileExists(string relativePath)
    {
        return File.Exists(GetFullPath(relativePath));
    }

    private void ValidateFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            throw new ArgumentException("Файл не выбран");
        }

        if (file.Length > _settings.MaxFileSizeBytes)
        {
            throw new ArgumentException($"Файл слишком большой. Максимум {_settings.MaxFileSizeMB} MB");
        }

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        
        if (!_settings.AllowedExtensions.Contains(extension))
        {
            throw new ArgumentException($"Тип файла {extension} не разрешён");
        }
    }

    [LoggerMessage(LogLevel.Information, "File saved: {Path}")]
    partial void LogFileSavedPath(string Path);
}