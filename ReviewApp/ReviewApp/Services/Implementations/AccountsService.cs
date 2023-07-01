using Microsoft.AspNetCore.Identity;
using ReviewApp.Models;
using ReviewApp.Services.Abstract;

namespace ReviewApp.Services.Implementations;

public class AccountsService : IAccountsService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountsService
    (
        UserManager<User> userManager,
        SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    public async Task<bool> RegisterUserAsync(string login, string email, string password)
    {
        var existingUserByLogin = await _userManager.FindByNameAsync(login);
        if (existingUserByLogin != null)
        {
            return false;
        }

        var existingUserByEmail = await _userManager.FindByEmailAsync(email);
        if (existingUserByEmail != null)
        {
            return false;
        }
        
        var user = new User()
        {  
            UserName = login,
            Email = email,
            SecurityStamp = Guid.NewGuid().ToString()
        };  
        
        var result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            return false;
        }

        return true;
    }

    public async Task<bool> LogInAsync(string login, string password)
    {
        var result = await _signInManager.PasswordSignInAsync
        (
            login,
            password,
            true,
            lockoutOnFailure: false
        );

        return result.Succeeded;
    }

    public async Task LogOutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}