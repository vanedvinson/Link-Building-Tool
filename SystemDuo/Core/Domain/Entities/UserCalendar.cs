namespace SystemDuo.Core.Domain.Entities
{
    public class UserCalendar
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public DateTime? Date { get; set; }
        public string? Note { get; set; }
    }
}
