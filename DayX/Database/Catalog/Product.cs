namespace DayX.Database.Catalog
{
    public class Product 
    { 
        Guid Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        Guid CategoryId { get; set; }
        ICollection<ProductAttributeValue> AttributeValues { get; set; }
        ICollection<ProductImage> Images { get; set; }
        ICollection<ProductTag> Tags { get; set; }
    }
}
