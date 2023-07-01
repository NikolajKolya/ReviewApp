using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReviewApp.Models.ViewModels.AccountViewModels;
using ReviewApp.Services.Abstract;

namespace ReviewApp.Controllers;

public class AccountController : Controller
{
    private readonly IAccountsService _accountsService;

    public AccountController(IAccountsService accountsService)
    {
        _accountsService = accountsService;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Login()
    {
        return View(new LoginViewModel());
    }
    
    [AllowAnonymous]
    public async Task<IActionResult> Register()
    {
        return View(new RegisterViewModel());
    }
    
    [HttpGet]
    public async Task<IActionResult> LogOut()
    {
        return View(null);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterPost(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Тут регистрируем пользователя
            var isSuccessful = await _accountsService.RegisterUserAsync(model.Login, model.Email, model.Password);

            if (!isSuccessful)
            {
                ModelState.AddModelError(string.Empty, "Произошла ошибка регистрации!");
                return View("Register", model);
            }
            
            return RedirectToAction(nameof(AccountController.Login), "Account");
        }

        return View("Register", model);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> LoginPost(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Тут мы входим на сайт
            var isLoggedIn = await _accountsService.LogInAsync(model.Login, model.Password);

            if (!isLoggedIn)
            {
                ModelState.AddModelError(string.Empty, "Неправильный логин или пароль!");
                return View("Login", model);
            }
            
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        return View("Login", model);
    }
    
    [HttpPost]
    public async Task<IActionResult> LogOutPost()
    {
        await _accountsService.LogOutAsync();

        return RedirectToAction(nameof(HomeController.Index), "Home");
    }

    [HttpPost]
    public async Task<IActionResult> GoBackPost()
    {
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }
    
    [AllowAnonymous]
    public async Task<IActionResult> AccessDenied()
    {
        return View(new AccessDeniedViewModel());
    }
}