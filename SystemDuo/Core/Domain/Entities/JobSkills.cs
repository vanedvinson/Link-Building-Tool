namespace SystemDuo.Core.Domain.Entities
{
    public class JobSkills
    {
        public Guid Id { get; set; }
        public Guid JobId { get; set; }
        public Guid SkillId { get; set; }
        public Skills? Skill { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; } //For soft delete

    }
}
