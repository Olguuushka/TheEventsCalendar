namespace TheEventsCalendar.DataAccess.Entities;

public class EventAccessEntity : BaseEntity
{
    public int FkEvent { get; set; }
    public int FkUser { get; set; }

    public EventsEntity Event { get; set; }
    public UserEntity User { get; set; }
}