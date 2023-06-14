using goods.DAO;
using goods.DAO.Abstract;
using goods.DAO.Implementations;
using goods.Mappers.Abstract;
using goods.Mappers.Implementations;
using Microsoft.EntityFrameworkCore;
using ReviewApp.Services.Abstract;
using ReviewApp.Services.Implementations;

namespace ReviewApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MainDbContext>();
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region Scoped

            builder.Services.AddScoped<IGoodsDao, GoodsDao>();
            builder.Services.AddScoped<ICommentsDao, CommentsDao>();
            builder.Services.AddScoped<IGoodsService, GoodsService>();
            builder.Services.AddScoped<ICommentsService, CommentsService>();

            #endregion

            #region Singletons

            builder.Services.AddSingleton<IGoodsMapper, GoodsMapper>();
            builder.Services.AddSingleton<ICommentsMapper, CommentsMapper>();

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}