using Microsoft.EntityFrameworkCore;
using ReviewApp.DAO.Models;
using File = ReviewApp.DAO.Models.File;

namespace ReviewApp.DAO
{
    public class MainDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        
        public MainDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Connect to sqlite database
            options.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
        }
        
        public DbSet<Good> Goods { get; set; }

        public DbSet<Comment> Comments { get; set; }
        
        public DbSet<File> Files { get; set; }
    }
}
