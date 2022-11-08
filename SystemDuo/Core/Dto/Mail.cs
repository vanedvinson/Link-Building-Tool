using System.ComponentModel.DataAnnotations.Schema;

namespace SystemDuo.Core.Dto
{
    [NotMapped]
    public class Mail
    {
        public string? ToEmail { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public bool IsBodyHtml { get; set; }
    }
}
