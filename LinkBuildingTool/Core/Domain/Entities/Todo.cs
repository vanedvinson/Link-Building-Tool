namespace LinkBuildingTool.Core.Domain.Entities
{
    public class Todo //this should be the Task, named it todo cause this f-ing thing thinks this a TASK
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public Status? Status { get; set; }
        public int? StatusGroup { get; set; } = 1;
        public LinkAttribute? LinkAttribute { get; set; }
        public LinkType? LinkType { get; set; }
        public DateTime? Published { get; set; }
        public DateTime? LastEdited { get; set; }
        public string? Theme { get; set; }
        public string? LinkTarget { get; set; }
        public string? AnchorText { get; set; }
        public double? BudgetAmount { get; set; } //for the client 
        public int? LinkAmount { get; set; } //for the client 
        public string? Note { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? Approve { get; set; }
        public double? Price { get; set; }
        public bool? ApprovePrice { get; set; }
        public string? TextLink { get; set; }
        public bool? IsFinished { get; set; }
        public string? ReasonForFinished { get; set; }
        public ClientDomain? Domain { get; set; }
        public Client? Client { get; set; }
        public DateTime? DeletedAt { get; set; }


    }
}
