using Microsoft.AspNetCore.Mvc;

namespace ProfMasteringProject.Controllers;

public class StoriesController : Controller
{
    [HttpGet("/stories")]
    public IActionResult Index()
    {
        return View();
    }
}