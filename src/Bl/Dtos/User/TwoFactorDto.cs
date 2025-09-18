namespace ECommerce.Bl.Dtos.User;

public class TwoFactorDto
{
    public string TwoFactorCode { get; set; }
    public bool RememberMe { get; set; }
    public bool RememberMachine { get; set; }
    public string Email { get; set; }
}

