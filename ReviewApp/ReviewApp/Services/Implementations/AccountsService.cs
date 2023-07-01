using Microsoft.AspNetCore.Identity;
using ReviewApp.Constants;
using ReviewApp.Models;
using ReviewApp.Services.Abstract;

namespace ReviewApp.Services.Implementations;

public class AccountsService : IAccountsService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountsService
    (
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
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

        if (login == GlobalConstants.AdminLogin)
        {
            // А существует-ли вообще администраторская роль?
            if (!(await _roleManager.RoleExistsAsync(GlobalConstants.AdminRoleName)))
            {
                if (!(await _roleManager.CreateAsync(new IdentityRole(GlobalConstants.AdminRoleName))).Succeeded)
                {
                    throw new InvalidOperationException($"Failed to create a role with a name { GlobalConstants.AdminRoleName }");
                }
            }
            
            if (!(await _userManager.AddToRoleAsync(user, GlobalConstants.AdminRoleName)).Succeeded)
            {
                throw new InvalidOperationException($"Failed to add user { user.UserName } to role { GlobalConstants.AdminRoleName }");
            }
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