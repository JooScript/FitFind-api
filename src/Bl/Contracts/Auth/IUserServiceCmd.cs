using ECommerce.Bl.Dtos.User;

namespace ECommerce.Bl.Contracts.Auth;

public interface IUserServiceCmd
{
    Task<UserResultDto> RegisterAsync(UserDto registerDto);

    Task<UserResultDto> LoginAsync(LoginDto loginDto);

    Task LogoutAsync();

    Task<UserResultDto> LoginWith2FAAsync(TwoFactorDto dto);

    Task<bool> ConfirmEmailAsync(Guid userId, string token);

    Task<bool> SendPasswordResetTokenAsync(string email);

    Task<bool> ResetPasswordAsync(ResetPasswordDto model);

}
