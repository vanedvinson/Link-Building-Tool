using System.ComponentModel.DataAnnotations;

namespace SystemDuo.Core.Dto
{
    public class UserForCreationOrUpdate
    {
        public string? Id { get; set; }
        [Required(ErrorMessage ="Field is required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string? Email { get; set; }
        public string? Password { get; set; }
       
        public string? MobileNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }

        public Guid CategoryId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Profession { get; set; }//zanimanje
        public string? Education { get; set; }
        public string? Note { get; set; }//polje za komentar
        public bool LongTerm { get; set; } //zaintersovan za dugorocni rad
        public bool ShortTerm { get; set; } //zaintersovan za kratkorocni rad
        public string? Language { get; set; }
        public string? Notes { get; set; }
        public IEnumerable<string>? RoleName { get; set; }
    }
}
