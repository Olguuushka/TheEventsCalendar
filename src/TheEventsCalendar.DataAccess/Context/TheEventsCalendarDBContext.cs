using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using TheEventsCalendar.DataAccess.Context.Configuration;
using TheEventsCalendar.DataAccess.Entities;
namespace TheEventsCalendar.DataAccess.Context;

public class TheEventsCalendarDBContext: DbContext
{
    public DbSet<UserEntity> Users{ get; set; }
    public DbSet<EventsEntity> Events{ get; set; }
    public DbSet<FavouriteEventsEntity> FavouriteEvents{ get; set; }
    public DbSet<EventAccessEntity> EventAccess{ get; set; }

    public TheEventsCalendarDBContext()
    {
        
    }

    public TheEventsCalendarDBContext(DbContextOptions<TheEventsCalendarDBContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureEventAccess();
        modelBuilder.ConfigureEvent();
        modelBuilder.ConfigureFavouriteEvents();
        modelBuilder.ConfigureUser();
    }
}