namespace LinkBuildingTool.Core.Domain.Entities
{
    public class Webmaster
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public bool? Title { get; set; }//anrede 0 mann 1 Frau
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? SocialMediaUrl { get; set; }
        public string? Note { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
