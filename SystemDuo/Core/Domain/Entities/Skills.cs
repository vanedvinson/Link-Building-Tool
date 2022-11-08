using System.ComponentModel.DataAnnotations;

namespace SystemDuo.Core.Domain.Entities
{
    public class Skills
    {
        public Guid Id { get; set; }
       
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; } //For soft delete
        public override string ToString()
        {
            return Name!;
        }

    }
}
