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
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

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

        app.UseStaticFiles();
        app.UseRouting(); // This adds route matching to the middleware pipeline
        app.UseAuthorization(); // This adds authorization capability

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();  // Maps attributes routes for controllers.
        });

        app.UseAntiforgery();

        // Map Blazor hub
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        // Run the application
        app.Run();
    }
}
