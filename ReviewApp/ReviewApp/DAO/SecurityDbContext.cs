using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReviewApp.Models;

namespace ReviewApp.DAO;

public class SecurityDbContext : IdentityDbContext<User>
{
    private readonly IConfiguration _configuration;

    public SecurityDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(_configuration.GetConnectionString("SecurityConnection"));
    }
}