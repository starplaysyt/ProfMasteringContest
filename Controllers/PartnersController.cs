using Microsoft.AspNetCore.Mvc;

namespace ProfMasteringProject.Controllers;

public class PartnersController : Controller
{
    [HttpGet("/partners")]
    public IActionResult Index()
    {
        return View();
    }
}