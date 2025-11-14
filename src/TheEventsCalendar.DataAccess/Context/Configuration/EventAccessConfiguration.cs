using Microsoft.EntityFrameworkCore;
using TheEventsCalendar.DataAccess.Entities;
namespace TheEventsCalendar.DataAccess.Context.Configuration;

public static class EventAccessConfiguration
{
    public static void ConfigureEventAccess(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventAccessEntity>().HasKey(u => u.Id);
        modelBuilder.Entity<EventAccessEntity>().HasIndex(u => u.ExternalId).IsUnique();
        modelBuilder.Entity<EventAccessEntity>().HasIndex(u => new { u.fkUser, u.fkEvent }).IsUnique();
        modelBuilder.Entity<EventAccessEntity>().Property(u => u.fkEvent).IsRequired();
        modelBuilder.Entity<EventAccessEntity>().Property(u => u.fkUser).IsRequired();
        modelBuilder.Entity<EventAccessEntity>().HasOne(ua => ua.Event).WithMany(e => e.EventAccesses)
            .HasForeignKey(ua => ua.fkEvent);
        modelBuilder.Entity<EventAccessEntity>().HasOne(ua => ua.User).WithMany(e => e.EventAccesses)
            .HasForeignKey(ua => ua.fkUser);
    }
}