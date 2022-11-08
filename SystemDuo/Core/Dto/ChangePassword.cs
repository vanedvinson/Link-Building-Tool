using System.ComponentModel.DataAnnotations;

namespace SystemDuo.Core.Dto
{
    public class ChangePassword
    {

        [Required(ErrorMessage = "Current Password is required.")]
        public string? OldPassword { get; set; }
        [Required(ErrorMessage = "New Password is required.")]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Password length minimal 8 and maximal 16 letters and must contain one Uppercase and number or special charachet")]
        [StringLength(16, MinimumLength = 7, ErrorMessage = "minimal 8")]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare(nameof(NewPassword), ErrorMessage = "Password don't match.")]
        public string? ConfirmPassword { get; set; }
    }
}
