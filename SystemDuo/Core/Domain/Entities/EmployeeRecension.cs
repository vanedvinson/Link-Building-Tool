namespace SystemDuo.Core.Domain.Entities
{
    public class EmployeeRecension
    {
        public Guid Id { get; set; }
        public Employee Employee { get; set; } = new();
        public Job Job { get; set; } = new();
        public string? Recension { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
