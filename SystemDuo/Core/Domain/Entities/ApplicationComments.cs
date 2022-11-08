namespace SystemDuo.Core.Domain.Entities
{
    public class ApplicationComments
    {
        public Guid Id { get; set; }
        public Guid? ApplicationId { get; set; }
        public Application? Application { get; set; }
        public string? UserId { get; set; } //who left comment
        public User? User { get; set; }
        public string? Comment { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } =DateTime.UtcNow;

    }
}
