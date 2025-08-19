namespace DayX.Database.Marketing
{
    public class Coupon
    {
        Guid Id { get; set; }
        string Code { get; set; }
        decimal Value { get; set; }
        DateTime ExpirationDate { get; set; }
        bool IsUsed { get; set; }
        Guid? UserId { get; set; }
    }
}
