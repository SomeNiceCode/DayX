namespace DayX.Database.Orders
{
    public class Order
    {
        Guid Id { get; set; }
        Guid UserId { get; set; }
        DateTime CreatedAt { get; set; }
        OrderStatus Status { get; set; }
        Guid AddressId { get; set; }
        ICollection<OrderItem> Items { get; set; }
        Payment Payment { get; set; }
        Shipment Shipment { get; set; }
    }
}
