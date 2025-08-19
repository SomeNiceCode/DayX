namespace DayX.Database.Carts
{
    public class Cart
    {
        Guid Id { get; set; }
        Guid UserId { get; set; }
        ICollection<CartItem> Items { get; set; }
    }
}
