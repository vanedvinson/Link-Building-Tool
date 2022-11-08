namespace SystemDuo.Core.Domain.Entities
{
    public class ClientDomain
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Theme { get; set; }
        public Webmaster? Webmaster  { get; set; }
        public string? Metrics { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
