namespace FragranceHub.Web
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using FragranceHub.Data.Models;
    using FragranceHub.Web.Infrastructure.Extensions;
    using FragranceHub.Services.Data.Interfaces;

    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<FragranceHubDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireLowercase"); 
                options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireUppercase"); 
                options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireNonAlphanumeric"); 
                options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:SignIn:RequiredLength");

            })        
                .AddEntityFrameworkStores<FragranceHubDbContext>();

            builder.Services.AddApplicationServices(typeof(IFragranceService));

            builder.Services.AddControllersWithViews();

            WebApplication app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            app.Run();
        }
    }
}