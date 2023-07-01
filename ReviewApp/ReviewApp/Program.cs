using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReviewApp.DAO;
using ReviewApp.DAO.Abstract;
using ReviewApp.DAO.Implementations;
using ReviewApp.Mappers.Abstract;
using ReviewApp.Mappers.Implementations;
using ReviewApp.Models;
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
            builder.Services.AddDbContext<SecurityDbContext>();
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region Scoped

            builder.Services.AddScoped<IFilesDao, FilesDao>();
            builder.Services.AddScoped<IGoodsDao, GoodsDao>();
            builder.Services.AddScoped<ICommentsDao, CommentsDao>();
            builder.Services.AddScoped<IGoodsService, GoodsService>();
            builder.Services.AddScoped<IFilesService, FilesService>();
            builder.Services.AddScoped<ICommentsService, CommentsService>();
            builder.Services.AddScoped<IAccountsService, AccountsService>();

            #endregion

            #region Singletons

            builder.Services.AddSingleton<IGoodsMapper, GoodsMapper>();
            builder.Services.AddSingleton<ICommentsMapper, CommentsMapper>();

            #endregion

            #region Identity

            // Identity
            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<SecurityDbContext>()
                .AddDefaultTokenProviders(); 

            // TODO: Move me to config
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredUniqueChars = 4;
            
                // User settings
                options.User.RequireUniqueEmail = true;
            });

            // Session
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(150);

                // If the LoginPath isn't set, ASP.NET Core defaults
                // the path to /Account/Login.
                options.LoginPath = "/Account/Login";

                // If the AccessDeniedPath isn't set, ASP.NET Core defaults
                // the path to /Account/AccessDenied.
                options.AccessDeniedPath = "/Account/AccessDenied";

                options.SlidingExpiration = true;
            });

            // Fallback policy - require authentification
            builder.Services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });

            builder.Services.AddHttpContextAccessor();
            
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (!app.Environment.IsDevelopment())
            //{
            app.UseExceptionHandler("/Home/Error");
            //}
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}