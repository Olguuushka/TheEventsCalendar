using Microsoft.EntityFrameworkCore;
using TheEventsCalendar.DataAccess.Entities;
namespace TheEventsCalendar.DataAccess.Context.Configuration;

public static class FavouriteEventConfiguration
{
    public static void ConfigureFavouriteEvents(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FavouriteEventsEntity>().HasKey(u => u.Id);

        modelBuilder.Entity<FavouriteEventsEntity>().HasIndex(u => u.ExternalId).IsUnique();
        modelBuilder.Entity<FavouriteEventsEntity>().HasIndex(u => new{u.fkUser,u.fkEvent}).IsUnique();
        modelBuilder.Entity<FavouriteEventsEntity>().Property(u => u.fkEvent).IsRequired();
        modelBuilder.Entity<FavouriteEventsEntity>().Property(u => u.fkUser).IsRequired();
        modelBuilder.Entity<FavouriteEventsEntity>().Property(u => u.DateOfChange).IsRequired();
        modelBuilder.Entity<FavouriteEventsEntity>().HasOne(fe => fe.Event).WithMany(u => u.FavouriteEvents)
            .HasForeignKey(fe => fe.fkEvent);
        modelBuilder.Entity<FavouriteEventsEntity>().HasOne(fe => fe.User).WithMany(u => u.FavouriteEvents)
            .HasForeignKey(fe => fe.fkUser);
    }
}