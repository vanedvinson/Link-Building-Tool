using System.ComponentModel.DataAnnotations;

namespace SystemDuo.Core.Dto
{
    public class ForgotPassword
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email isn't valid.")]
        public string? Email { get; set; }
    }
}
