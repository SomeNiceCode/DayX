namespace DayX.Database.Users
{
    public class FavoriteProduct
    {
        Guid Id { get; set; }
        Guid UserId { get; set; }
        Guid ProductVariantId { get; set; }
        DateTime AddedAt { get; set; }
    }
}
