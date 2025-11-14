using TheEventsCalendar.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using TheEventsCalendar.DataAccess.Context;

namespace TheEventsCalendar.DataAccess.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly IDbContextFactory<TheEventsCalendarDBContext> _contextFactory;

    public Repository(IDbContextFactory<TheEventsCalendarDBContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public IQueryable<T> GetAll()
    {
        using var context = _contextFactory.CreateDbContext();
        return context.Set<T>();
    }

    public T? GetById(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        return context.Set<T>().FirstOrDefault(x => x.Id == id);
    }

    public T? GetById(Guid id)
    {
        using var context = _contextFactory.CreateDbContext();
        return context.Set<T>().FirstOrDefault(x => x.ExternalId == id);
    }

    public T Save(T entity)
    {
        using var context = _contextFactory.CreateDbContext();

        if (context.Set<T>().Any(x => x.Id == entity.Id)) // update
        {
            entity.ModificationTime = DateTime.UtcNow;
            var result = context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return result.Entity;
        }
        else // insert
        {
            entity.ExternalId = Guid.NewGuid();
            entity.CreationTime = DateTime.UtcNow;
            entity.ModificationTime = entity.CreationTime;
            var result = context.Set<T>().Add(entity);
            context.SaveChanges();
            return result.Entity;
        }
    }

    public void Delete(T entity)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Set<T>().Attach(entity);
        context.Entry(entity).State = EntityState.Deleted;
        context.SaveChanges();
    }
}