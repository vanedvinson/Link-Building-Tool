using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Dto
{
    public class JobForCreationDto
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; } //Requirements 
       // public string? Location { get; set; }
        public string? Type { get; set; } //Full-Time, Part-Time
        public string? ExperienceLevel { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public Guid CompanyId { get; set; } 
        //TODO delete this
        public Guid? LocationId { get; set; }
        public string? JobLocation { get; set; } //only string separated by comma
        public string? AssignedToId { get; set; } //assign to agent
        public string? EducationLevel { get; set; }
        public string? Language { get; set; }   
        public string? Notes { get; set; }
        public IEnumerable<Skills>? Skills { get; set; }
       
    }
}
