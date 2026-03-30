using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProfMasteringProject.Controllers;

public class VolunteerController : Controller
{
    [HttpGet("/volunteer")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/gratitudes")]
    public IActionResult Gratitude()
    {
        return View();
    }

    [HttpGet("/personal")]
    [Authorize(Roles = "Volunteer")]
    public IActionResult VolunteerPage()
    {
        return View();
    }
}