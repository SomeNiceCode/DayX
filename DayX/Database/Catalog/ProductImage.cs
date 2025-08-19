namespace DayX.Database.Catalog
{
    public class ProductImage 
    { 
        Guid Id { get; set; }
        Guid ProductId { get; set; }
        string Url { get; set; }
        int Order { get; set; } 
    }
}
