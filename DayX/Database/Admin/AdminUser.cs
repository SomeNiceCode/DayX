namespace DayX.Database.Admin
{
    public class AdminUser
    {
        Guid Id { get; set; }
        string Email { get; set; }
        string PasswordHash { get; set; }
        string Role { get; set; }
    }
}
