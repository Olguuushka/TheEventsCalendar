namespace TheEventsCalendar.DataAccess.Entities;

public class FavouriteEventsEntity:BaseEntity
{
    public int fkEvent { get; set; }
    public int fkUser { get; set; }
    public DateTime DateOfChange { get; set; }

    public EventsEntity Event { get; set; }
    public UserEntity User { get; set; }
}