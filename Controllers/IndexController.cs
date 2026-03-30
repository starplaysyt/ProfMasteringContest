using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProfMasteringProject.Entities;
using ProfMasteringProject.Models;
using ProfMasteringProject.Persistence;

namespace ProfMasteringProject.Controllers;

public class IndexController(AppDbContext context) : Controller
{
    public AppDbContext Context { get; set; } = context;
    
    [HttpGet("/")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/about-us")]
    public IActionResult AboutUs()
    {
        return View();
    }

    [HttpGet("/faq")]
    public IActionResult FAQ()
    {
        return View();
    }

    [HttpGet("/help-us")]
    public IActionResult HelpUs()
    {
        return View();
    }

    [HttpGet("/contact-us")]
    public IActionResult ContactUs()
    {
        return View();
    }

    [HttpGet("/addrecord")]
    public IActionResult AddRecord()
    {
        Context.DataRoles.Add(new DataRoleEntity()
        {
            RoleType = "TestRoleType"
        });
        Context.SaveChanges();
        
        return Ok("thats ok yee");
    }
}