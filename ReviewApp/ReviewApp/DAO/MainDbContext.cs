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
        private string _dbPath;

        public MainDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            _dbPath = System.IO.Path.Join(path, "goods.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={ _dbPath }");
        }
        
        public DbSet<Good> Goods { get; set; }
    }
}
