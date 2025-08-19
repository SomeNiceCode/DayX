namespace DayX.Database.PayDelivery
{
    public class Shipment
    {
        Guid Id { get; set; }
        Guid OrderId { get; set; }
        string TrackingNumber { get; set; }
        DateTime ShippedAt { get; set; }
        DateTime? DeliveredAt { get; set; }
        Guid DeliveryMethodId { get; set; }
    }
}
