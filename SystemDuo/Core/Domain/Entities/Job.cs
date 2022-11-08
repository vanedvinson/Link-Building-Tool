using System.ComponentModel.DataAnnotations.Schema;

namespace SystemDuo.Core.Domain.Entities
{
    public class Job
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? ShortDescription { get; set; } 
        public string? Description { get; set; } //Requirements 
        public string? Type { get; set; } //Long-Term, Short-Term
        public string? ExperienceLevel { get; set; }
        public DateTime? StartDate { get; set; } 
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }

        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }      
        public string? AssignedToId { get; set; } //assign to agent
        public User? AssignedTo { get; set; }          
        public Guid? LocationId { get; set; }
        public Location? Location { get; set; }
        public string? JobLocation { get; set; } //only string separated by comma
        public string? EducationLevel { get; set; }
        public string? Language { get; set; }
       
        public string? Notes { get; set; }
       // public ICollection<Documents>? Documents { get; set; } //RequiredDocuments
        public ICollection<Application>? CandidateApplications { get; set; }
        public ICollection<JobSkills>? JobSkills { get; set;} //Required skills for the jobs
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; 
        public DateTime? DeletedAt { get; set; } //For soft delete

        [NotMapped]
        public bool ShowDetails { get; set; }

        public override string ToString()
        {
            return Name!;
        }


    }
}
