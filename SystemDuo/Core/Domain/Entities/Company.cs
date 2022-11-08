using System.ComponentModel.DataAnnotations.Schema;

namespace SystemDuo.Core.Domain.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MobileNumber { get; set; }
        //public string? City { get; set; }
        //public string? Country { get; set; }
        //public string? Address { get; set; }
        //public string? PostalCode { get; set; }
       
        public string? TaxNumber { get; set; }
        public int OpenPositionNumber { get; set; }
        public bool LongTerm { get; set; } //moze biti oboje
        public bool ShortTerm { get; set; } //moze biti oboje
        public string? Note { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        public Guid LocationId { get; set; }
        public Location? Location { get; set; }
        public ICollection<Job>? Jobs { get; set; } = new List<Job>();//oglasi 
        //public ICollection<Employee>? Employees { get; set; } //trenutni zaposleni 
        public ICollection<Application>? Applications { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; } //For soft delete
        public override string ToString() => Name!;


        [NotMapped]
        public bool ShowDetails { get; set; }
      
    }
}
