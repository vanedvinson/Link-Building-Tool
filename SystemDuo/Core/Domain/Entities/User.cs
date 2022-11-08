using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemDuo.Core.Domain.Entities
{
    public class User: IdentityUser
    {
        public string? FirstName { get; set; } = "";
        public string? LastName { get; set; } = "";
        public string? MobileNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Profession { get; set; }//zanimanje
        public string? Education { get; set; }
        public string? Note { get; set; }//polje za komentar
        public bool LongTerm { get; set; } //zaintersovan za dugorocni rad
        public bool ShortTerm { get; set; } //zaintersovan za kratkorocni rad
        public string? Language { get; set; }
        public string? Notes { get; set; } //komentar
        public string? Country { get; set; }

        public string? City { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public bool IsWorking { get; set; }
        public bool IsEmployee { get; set; }
        public string? PasswordResetToken { get; set; }
        public string? EmailConfirmationToken { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; } //For soft delete
        public Guid? CategoryId { get; set; }
        public virtual Category? Category { get; set; } //category of interest ?? 
        public ICollection<Application>? CandidateApplications { get; set; }
        public ICollection<ApplicantSkills>? CandidateSkills { get; set; }
        public virtual ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
   
        public ICollection<EmployeeJob> EmployeeJob { get; set; } = new List<EmployeeJob>(); //trenutna pozicija??  zadnja ako nema end date?                                                                                           
        
        
        
        [NotMapped]
        public bool ShowDetails { get; set; }

        [NotMapped]
        public ICollection<string>? UserRoles1 { get; set; }


        public override string ToString() => FirstName + " " + LastName;
        
    }
}
