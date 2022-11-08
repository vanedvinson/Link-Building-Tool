namespace SystemDuo.Core.Domain.Entities
{
    public class EmployeeJob
    {
        public Guid Id { get; set; }
        public Job Job { get; set; } = new();
        public User User { get; set; } = new();

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; } 
       
    }
}
