namespace LinkBuildingTool.Core.Domain.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public ClientType? Type { get; set; }
        public string? PrioUrl { get; set; }
        public string? Note { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
