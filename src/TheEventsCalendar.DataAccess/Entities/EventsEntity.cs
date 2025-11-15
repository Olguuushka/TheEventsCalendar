namespace TheEventsCalendar.DataAccess.Entities;

public class EventsEntity : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DateTime { get; set; }
    public string Location { get; set; }
    public int Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public int AgeLink { get; set; }
    public int UserId { get; set; }
    public byte[] Image { get; set; }

    //public UserEntity User { get; set; }
    public ICollection<FavouriteEventsEntity> FavouriteEvents { get; set; }
    public ICollection<EventAccessEntity> EventAccesses { get; set; }
}