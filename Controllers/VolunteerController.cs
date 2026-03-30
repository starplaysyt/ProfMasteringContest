using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
    [Authorize]
    public IActionResult VolunteerPage()
    {
        if (User.IsInRole("volunteer"))
            return View("VolunteerPage");
        if (User.IsInRole("admin"))
            return View("AdminPage");
        if (User.IsInRole("manager"))
            return View("ManagerPage");

        return View("VolunteerPage");
    }
}