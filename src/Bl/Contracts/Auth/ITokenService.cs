using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace ECommerce.Bl.Contracts.Auth;

public interface ITokenService
{
    public string GenerateAccessToken(IEnumerable<Claim> claims);

    public string GenerateRefreshToken();
}