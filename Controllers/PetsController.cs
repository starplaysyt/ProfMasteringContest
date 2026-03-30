using Microsoft.AspNetCore.Mvc;

namespace ProfMasteringProject.Controllers;

public class PetsController : Controller
{
    [HttpGet("pets/")]
    public IActionResult Index()
    {
        return View();
    }
}