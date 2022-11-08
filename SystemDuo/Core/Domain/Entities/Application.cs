namespace SystemDuo.Core.Domain.Entities
{
    public class Application
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public Guid? JobId { get; set; }
        public Job Job { get; set; }
       
        public bool IsAcceptedForInterview { get; set; }
        public bool IsRequestFromAgent { get; set; } 
        public bool IsHired { get; set; }
        public bool IsRejected { get; set; }
        public string? RejectReason { get; set; }
        public ICollection<ApplicationComments>? ApplicationComments { get; set; } = new List<ApplicationComments>();   
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        
    }
}
