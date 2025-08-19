namespace DayX.Database.Admin
{
    public class Notification
    {
        Guid Id { get; set; }
        Guid UserId { get; set; }
        string Message { get; set; }
        bool IsRead { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
