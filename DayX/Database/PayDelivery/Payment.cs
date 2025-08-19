namespace DayX.Database.PayDelivery
{
    public class Payment
    {
        Guid Id { get; set; }
        Guid OrderId { get; set; }
        string Provider { get; set; }
        string Status { get; set; }
        DateTime PaidAt { get; set; }
    }
}
