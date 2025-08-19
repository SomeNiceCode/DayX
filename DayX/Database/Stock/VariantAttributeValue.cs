namespace DayX.Database.Stock
{
    public class VariantAttributeValue
    {
        Guid Id { get; set; }
        Guid ProductVariantId { get; set; }
        Guid CategoryAttributeId { get; set; }
        string Value { get; set; }
    }
}
