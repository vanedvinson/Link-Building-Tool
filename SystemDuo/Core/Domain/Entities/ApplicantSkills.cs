namespace SystemDuo.Core.Domain.Entities
{
    public class ApplicantSkills
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; }
        public Guid SkillId { get; set; }
        public Skills? Skill { get; set; }
    }    
}
