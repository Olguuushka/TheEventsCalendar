namespace TheEventsCalendar.DataAccess.Entities;

public class EventAccessEntity:BaseEntity
{
    public int fkEvent { get; set; }
    public int fkUser { get; set; }

    public EventsEntity Event { get; set; }
    public UserEntity User { get; set; }
}