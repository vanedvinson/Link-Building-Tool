using Microsoft.AspNetCore.Identity;

namespace LinkBuildingTool.Core.Domain.Entities
{
    public class Role:IdentityRole
    {
        public string? Type { get; set; }
        public virtual ICollection<UserRole> Roles { get; } = new List<UserRole>();

    }
}
