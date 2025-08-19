namespace DayX.Database.Orders
{
    public class OrderItem
    {
        Guid Id { get; set; }
        Guid OrderId { get; set; }
        Guid ProductVariantId { get; set; }
        int Quantity { get; set; }
        decimal UnitPrice { get; set; }
    }
}
