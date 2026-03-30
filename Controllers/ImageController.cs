using Microsoft.AspNetCore.Mvc;

namespace ProfMasteringProject.Controllers;

public class ImageController
{
    [HttpGet("/images/{id:int}")]
    public async Task<IActionResult> GetImage(int id)
    {
        var type = GetContentType("asdasd");
        
        return new PhysicalFileResult("Images/" + id.ToString(), "image/jpeg");
    }
    
    private string GetContentType(string fileName)
    {
        var ext = Path.GetExtension(fileName).ToLowerInvariant();
        return ext switch
        {
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            ".webp" => "image/webp",
            ".svg" => "image/svg+xml",
            ".pdf" => "application/pdf",
            _ => "application/octet-stream"
        };
    }

}