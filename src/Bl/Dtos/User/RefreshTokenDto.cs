using ECommerce.Bl.Dtos.Base;
using static ECommerce.Bl.Enums.Status.Status;

namespace ECommerce.Bl.Dtos.User;

public class RefreshTokenDto : BaseDto<enCurrentState>
{
    public string Token { get; set; }

    public Guid UserId { get; set; }

    public DateTime Expires { get; set; }

}
