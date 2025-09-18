using AutoMapper;
using ECommerce.Bl.Contracts.Auth;
using ECommerce.Bl.Contracts.Events;
using ECommerce.Bl.Dtos.User;
using ECommerce.Bl.Services.Base;
using ECommerce.Da.Contracts;
using ECommerce.Domains.Models;
using static ECommerce.Bl.Enums.Status.Status;

namespace ECommerce.Bl.Services.Auth;

public class RefreshTokenService(ITableRepoQry<TbRefreshToken> repoQuery, ITableRepoCmd<TbRefreshToken> repoCommand, IMapper mapper, IUserServiceQry userService, ICrudPublisher publisher) : BaseService<TbRefreshToken, RefreshTokenDto>(repoQuery, repoCommand, mapper, userService, publisher), IRefreshTokens
{
    public async Task<bool> Refresh(RefreshTokenDto tokenDto)
    {
        var tokenList = await repoQuery.GetListAsync(a => a.UserId == tokenDto.UserId && a.CurrentState == (int)enCurrentState.Active);
        foreach (var dbToken in tokenList)
        {
            await repoCommand.ChangeStatusAsync(dbToken.Id, tokenDto.UserId, (int)enCurrentState.InActive);
        }

        var dbTokens = mapper.Map<RefreshTokenDto, TbRefreshToken>(tokenDto);
        await repoCommand.AddAsync(dbTokens);
        return true;
    }

    public async Task<RefreshTokenDto> GetByToken(string token) => mapper.Map<TbRefreshToken, RefreshTokenDto>(await repoQuery.GetFirstOrDefaultAsync(a => a.Token == token));

}
