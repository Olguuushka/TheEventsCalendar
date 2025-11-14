namespace TheEventsCalendar.Service.Settings;

public class TheEventsCalendarSettingsReader
{
    public static TheEventsCalendarSettings Read(IConfiguration configuration)
    {
        return new TheEventsCalendarSettings()
        {
            TheEventsCalendarDbConnectionString = configuration.GetConnectionString("TheEventCalendarDbContext")!
        };
    }
}