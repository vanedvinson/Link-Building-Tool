namespace SystemDuo.Core.Domain.Entities
{
    public class Location
    {
        public Guid Id { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } =DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
        public override string ToString() => Country + ", " + City + ", " + Address;
      
    }
}
