using System.ComponentModel.DataAnnotations.Schema;

namespace LinkBuildingTool.Core.Dto
{
    [NotMapped]
    public class MailSettings
    {
        public string? Mail { get; set; }
        public string? DisplayName { get; set; }
        public string? Password { get; set; }
        public string? ImapHost { get; set; }
        public string? SmtpHost { get; set; }
        public int ImapPort { get; set; }
        public int SmtpPort { get; set; }
    }
}
