using Microsoft.AspNetCore.Mvc;

namespace ProfMasteringProject.Controllers;

public class ReportsController : Controller
{
    [HttpGet("/reports")]
    public IActionResult Index()
    {
        return View();
    }
}