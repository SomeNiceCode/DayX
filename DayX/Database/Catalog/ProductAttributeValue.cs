namespace DayX.Database.Catalog
{
    public class ProductAttributeValue
    {
        Guid Id { get; set; }
        Guid ProductId { get; set; }
        Guid CategoryAttributeId { get; set; }
        string Value { get; set; }
    }
}
