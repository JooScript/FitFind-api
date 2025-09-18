using ECommerce.Bl.Dtos.User;
using System.Security.Claims;

namespace ECommerce.Bl.Contracts.Auth;

public interface IUserServiceQry
{
    Task<UserDto> GetUserByIdAsync(Guid userId);

    Task<UserDto> GetUserByEmailAsync(string email);

    Task<IEnumerable<UserDto>> GetAllUsersAsync();

    Guid GetLoggedInUserId();
    Task<IEnumerable<string>> GetUserRolesAsync(Guid userId);
    Task<(Claim[] claims, UserDto user)> GetClaims(Guid userId);
    Task<(Claim[] claims, UserDto user)> GetClaims(string email);
}
