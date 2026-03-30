using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProfMasteringProject.DTO;
using ProfMasteringProject.Entities;
using ProfMasteringProject.PageModels;
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
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        await service.ValidateUserRegistration(dto);

        if (await service.RegisterUser(dto) != 1) 
            return BadRequest();

        return RedirectToAction("Login", "User");
    }

    [HttpPost("/login")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LoginPost([FromForm] UserLoginDTO dto)
    {
        Console.WriteLine("Login seq started");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        // 1. Поиск пользователя
        var user = await service.LoginUser(dto);

        if (user == null)
        {
            return View("Login", new LoginPageModel() { ExceptionLine = "Неверный логин или пароль."});
        }

        var roleName = (await service.GetUserRole(user))?.Name;

        // 3. Создание Claims (данные пользователя в куке)
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.GivenName, user.FirstName),
            new(ClaimTypes.Surname, user.SecondName),
            new("FullName", $"{user.FirstName} {user.SecondName}"),
            new("AvatarUrl", $"{user.AvatarPicturePath}"),
            new(ClaimTypes.Role, roleName ?? "volunteer") // Роль пользователя
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        // 4. Настройки аутентификации
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = dto.RememberMe == "on" ? true : false,  // "Запомнить меня"
            ExpiresUtc = dto.RememberMe == "on"
                ? DateTimeOffset.UtcNow.AddDays(30) 
                : DateTimeOffset.UtcNow.AddHours(2),
            AllowRefresh = true
        };

        // 5. Вход (установка куки)
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            claimsPrincipal,
            authProperties
        );

        Console.WriteLine("Login seq ended");
        
        // 6. Обновление времени последнего входа
        await service.UpdateEntityLoginTime(user, DateTime.UtcNow);
        
        return RedirectToAction("VolunteerPage", "Volunteer");
    }

    [HttpGet("/logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        
        return RedirectToAction("Login");
    }
}