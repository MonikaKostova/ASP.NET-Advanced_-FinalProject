using CalorieTrackerCookBookApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CalorieTrackerCookBookApp.Controllers;
using CalorieTrackerCookBookApp.Services;
using CalorieTrackerCookBookApp.Services.Interfaces;


namespace CalorieTrackerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register DbContext with the connection string
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register Identity with the custom User class
            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add other services like controllers
            builder.Services.AddControllersWithViews();

            // Service registration
            //builder.Services.AddScoped<IUserService, UserService>();
            //builder.Services.AddScoped<IRecipeService, RecipeService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            //builder.Services.AddScoped<IFavoriteService, FavoriteService>();
            //builder.Services.AddScoped<IIngredientService, IngredientService>();

            var app = builder.Build();

            // Use authentication and authorization
            app.UseAuthentication();
            app.UseAuthorization();

            // Map controllers and views
            app.MapControllers();
            app.Run();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        
    }
}
