using Microsoft.EntityFrameworkCore;
using TheEventsCalendar.DataAccess.Entities;
namespace TheEventsCalendar.DataAccess.Context.Configuration;

public static class UserConfiguration
{
    public static void ConfigureUser(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasKey(u => u.Id);

        modelBuilder.Entity<UserEntity>().HasIndex(u => u.ExternalId).IsUnique();
        modelBuilder.Entity<UserEntity>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<UserEntity>().HasIndex(u => u.Username).IsUnique();
        modelBuilder.Entity<UserEntity>().HasIndex(u => u.Login).IsUnique();
        modelBuilder.Entity<UserEntity>().Property(u => u.Email).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<UserEntity>().Property(u => u.Username).HasMaxLength(20).IsRequired();
        modelBuilder.Entity<UserEntity>().Property(u => u.Login).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<UserEntity>().Property(u => u.BirthDate).IsRequired();
        modelBuilder.Entity<UserEntity>().Property(u => u.CreatedAt).IsRequired();
        modelBuilder.Entity<UserEntity>().Property(e => e.UserRole).HasConversion<int>().IsRequired();
    }

}