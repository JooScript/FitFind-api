using ECommerce.Bl.Contracts.Base;
using ECommerce.Bl.Dtos.User;
using ECommerce.Domains.Models;

namespace ECommerce.Bl.Contracts.Auth;

public interface IRefreshTokens : IBaseService<TbRefreshToken, RefreshTokenDto>
{
    public Task<bool> Refresh(RefreshTokenDto tokenDto);

    public Task<RefreshTokenDto> GetByToken(string token);

}
