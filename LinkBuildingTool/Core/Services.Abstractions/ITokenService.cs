using System.Security.Claims;
using LinkBuildingTool.Core.Domain.Entities;

namespace LinkBuildingTool.Core.Services.Abstractions
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromToken(string token);
        Task<User> GetUserFromAccessToken(string token);
     
    }
}
