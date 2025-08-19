namespace DayX.Database.Stock
{
    public class StockEntry
    {
        Guid Id { get; set; }
        Guid ProductVariantId { get; set; }
        int QuantityChange { get; set; }
        DateTime Timestamp { get; set; }
        string Reason { get; set; }
    }
}
