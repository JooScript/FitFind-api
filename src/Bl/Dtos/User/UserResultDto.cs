namespace ECommerce.Bl.Dtos.User;

public class UserResultDto
{
    public bool Success { get; set; }
    public string Token { get; set; }
    public List<string> Errors { get; set; }
    public string? Email { get; set; }
    public string UserId { get; set; }
    public bool Requires2FA { get; set; }
}
