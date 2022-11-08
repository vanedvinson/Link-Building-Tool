using System.ComponentModel.DataAnnotations.Schema;
using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }      
        [NotMapped]
        public DateTime? HireDate { get; set; }
        //public ICollection<EmployeeJob> EmployeeJob { get; set; } = new List<EmployeeJob>(); //trenutna pozicija??  zadnja ako nema end date?                                                                                           
        public string? UserId { get; set; }
        public User? User { get; set; }

        [NotMapped]
        public bool ShowDetails { get; set; }
    }
}
