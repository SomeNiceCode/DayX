namespace DayX.Database.Catalog
{
    public class Tag 
    { 
        Guid Id { get; set; }
        string Name { get; set; }
        ICollection<ProductTag> ProductTags { get; set; }
    }
}
