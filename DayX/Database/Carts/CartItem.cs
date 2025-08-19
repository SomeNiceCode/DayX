namespace DayX.Database.Carts
{
    public class CartItem
    {
        Guid Id { get; set; }
        Guid CartId { get; set; }
        Guid ProductVariantId { get; set; }
        int Quantity { get; set; }
    }
}
