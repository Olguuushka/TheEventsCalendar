using Microsoft.EntityFrameworkCore;
using TheEventsCalendar.DataAccess.Context;
using TheEventsCalendar.Service.Settings;

namespace TheEventsCalendar.Service.IoC;

public class DbContextConfigurator
{
    public static void ConfigureServices(IServiceCollection services, TheEventsCalendarSettings settings)
    {
        services.AddDbContextFactory<TheEventsCalendarDBContext>(options =>
        {
            options.UseNpgsql(settings.TheEventsCalendarDbConnectionString);},
            ServiceLifetime.Scoped);
    }
    
    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<TheEventsCalendarDBContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate(); //makes last migrations to db and creates database if it doesn't exist
    }
}