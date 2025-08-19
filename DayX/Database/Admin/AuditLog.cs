namespace DayX.Database.Admin
{
    public class AuditLog
    {
        Guid Id { get; set; }
        string Action { get; set; }
        string Entity { get; set; }
        Guid? EntityId { get; set; }
        Guid AdminUserId { get; set; }
        DateTime Timestamp { get; set; }
    }
}
