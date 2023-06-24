using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReviewApp.Models.ViewModels.AccountViewModels;

namespace ReviewApp.Controllers;

public class AccountController: Controller
{
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
}