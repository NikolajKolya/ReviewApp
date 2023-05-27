using Microsoft.EntityFrameworkCore;
using goods.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods.DAO
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
    }
}
