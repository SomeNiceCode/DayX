namespace DayX.Database.PayDelivery
{
    public class DeliveryMethod
    {
        Guid Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
        TimeSpan EstimatedTime { get; set; }
    }
}
