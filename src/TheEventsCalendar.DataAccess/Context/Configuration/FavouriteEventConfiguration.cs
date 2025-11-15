using Microsoft.EntityFrameworkCore;
using TheEventsCalendar.DataAccess.Entities;
namespace TheEventsCalendar.DataAccess.Context.Configuration;

public static class FavouriteEventConfiguration
{
    public static void ConfigureFavouriteEvents(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FavouriteEventsEntity>().HasKey(u => u.Id);

        modelBuilder.Entity<FavouriteEventsEntity>().HasIndex(u => u.ExternalId).IsUnique();
        modelBuilder.Entity<FavouriteEventsEntity>().HasIndex(u => new{u.FkUser,u.FkEvent}).IsUnique();
        modelBuilder.Entity<FavouriteEventsEntity>().Property(u => u.FkEvent).IsRequired();
        modelBuilder.Entity<FavouriteEventsEntity>().Property(u => u.FkUser).IsRequired();
        modelBuilder.Entity<FavouriteEventsEntity>().Property(u => u.DateOfChange).IsRequired();
        modelBuilder.Entity<FavouriteEventsEntity>().HasOne(fe => fe.Event).WithMany(u => u.FavouriteEvents)
            .HasForeignKey(fe => fe.FkEvent);
        modelBuilder.Entity<FavouriteEventsEntity>().HasOne(fe => fe.User).WithMany(u => u.FavouriteEvents)
            .HasForeignKey(fe => fe.FkUser);
    }
}