namespace DayX.Database.Stock
{
    public class ProductVariant
    {
        Guid Id { get; set; }
        Guid ProductId { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
        int StockQuantity { get; set; }

        ICollection<VariantAttributeValue> AttributeValues { get; set; }
    }
}
