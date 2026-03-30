using Microsoft.AspNetCore.Mvc;
using ProfMasteringProject.Models;

namespace ProfMasteringProject.Controllers;

public class ErrorController : Controller
{
    [HttpGet("/error")]
    public IActionResult Error(string error)
    {
        return View(new ErrorViewModel() { RequestId = error});
    }
    
    [HttpGet("/error500")]
    public IActionResult Error500(string error)
    {
        return View(new ErrorViewModel() { RequestId = error});
    }

    [HttpGet("{**catchAll}")]
    public IActionResult Error404()
    {
        return View(new ErrorViewModel() { RequestId = "ajsdjnaskd"});
    }
}