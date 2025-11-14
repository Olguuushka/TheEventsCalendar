using Microsoft.EntityFrameworkCore;
using TheEventsCalendar.DataAccess.Entities;
namespace TheEventsCalendar.DataAccess.Context.Configuration;

public static class EventConfiguration
{
    public static void ConfigureEvent(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventsEntity>().HasKey(u => u.Id);

        modelBuilder.Entity<EventsEntity>().HasIndex(u => u.ExternalId).IsUnique();
        modelBuilder.Entity<EventsEntity>().Property(u => u.Title).HasMaxLength(255).IsRequired();
        modelBuilder.Entity<EventsEntity>().Property(u => u.Description).IsRequired();
        modelBuilder.Entity<EventsEntity>().Property(u=>u.DateTime).IsRequired();
        modelBuilder.Entity<EventsEntity>().Property(u => u.Location).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<EventsEntity>().Property(u=>u.Price).IsRequired();
        modelBuilder.Entity<EventsEntity>().Property(u=>u.CreatedAt).IsRequired();
        modelBuilder.Entity<EventsEntity>().Property(u=>u.AgeLink).IsRequired();
        modelBuilder.Entity<EventsEntity>().Property(u=>u.UserId).IsRequired();
        modelBuilder.Entity<EventsEntity>().HasOne(u => u.User).WithMany(e => e.Events).HasForeignKey(u => u.UserId);

    }
}