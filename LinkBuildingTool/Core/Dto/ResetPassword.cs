using System.ComponentModel.DataAnnotations;

namespace LinkBuildingTool.Core.Dto
{
    public class ResetPassword
    {
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string? NewPassword { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Compare(nameof(NewPassword), ErrorMessage = "Password don't match")]
        public string? ConfirmPassword { get; set; }
        public string? ResetPasswordToken { get; set; }
    }
}
