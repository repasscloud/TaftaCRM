using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TaftaCRM.Components;
using TaftaCRM.Data;

namespace TaftaCRM;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddBlazorBootstrap();
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        // authentication and authorization
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "taftacrm_auth_token";
                options.LoginPath = "/login";
                options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
                options.AccessDeniedPath = "/access-denied";
            });
        builder.Services.AddAuthorization();
        builder.Services.AddCascadingAuthenticationState();

        // PostgreSQL
        builder.Services.AddDbContext<TaftaDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("PgsqlConnection")));
        
        // Add Controllers for API support
        builder.Services.AddControllers();
        // Swagger configuration
        builder.Services.AddSwaggerGen();

        // Initialize PasswordHasher with configuration settings
        Helpers.PasswordHasher.Initialize(builder.Configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }
        else
        {
            app.UseSwagger(); // Enable Swagger only in development
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Blazor API V1");
            });
        }

        /*
         * moved down
         */
        // app.UseStaticFiles();
        app.UseRouting(); // This adds route matching to the middleware pipeline
        app.UseAuthorization(); // This adds authorization capability

        /*
         * moved down
         */
        // app.UseEndpoints(endpoints =>
        // {
        //     endpoints.MapControllers();  // Maps attributes routes for controllers.
        // });

        app.UseStaticFiles();
        app.UseAntiforgery();

        // Map Blazor hub
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.MapControllers();

        // Run the application
        app.Run();
    }
}
