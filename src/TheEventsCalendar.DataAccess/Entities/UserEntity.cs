using TheEventsCalendar.DataAccess.Entities.Primitives;
namespace TheEventsCalendar.DataAccess.Entities;

    public class UserEntity : BaseEntity
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Login { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }

        public int FkUserRole { get; set; }
        public UserRole UserRole { get; set; }

        public ICollection<FavouriteEventsEntity> FavouriteEvents { get; set; }
        public ICollection<EventAccessEntity> EventAccesses { get; set; }
        //public ICollection<EventsEntity> Events { get; set; }
    }