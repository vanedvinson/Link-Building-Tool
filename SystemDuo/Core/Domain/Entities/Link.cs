namespace SystemDuo.Core.Domain.Entities
{
    public class Link
    {
        public Guid Id { get; set; }
        public string? Url { get; set; }
        public string? TimeInterval { get; set; }
        public decimal? PriceNetto { get; set; }
        public string? InclExclText { get; set; }
        public string? Note { get; set; }
        public decimal? ContentPrice { get; set; }
        public User? LinkBuilder { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
