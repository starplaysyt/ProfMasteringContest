using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfMasteringProject.DTO;
using ProfMasteringProject.Entities;
using ProfMasteringProject.Services;

namespace ProfMasteringProject.Controllers;

public class UserController (UserService service) : Controller
{
    [HttpGet("/login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpGet("/register")]
    public async Task<IActionResult> Register()
    {
        return View();
    }

    [HttpPost("/register")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RegisterPost([FromForm] UserRegistrationDTO dto)
    {
        await service.ValidateUserRegistration(dto);

        if (await service.RegisterUser(dto) != 1) 
            return BadRequest();
        
        return Ok(dto);
    }
}