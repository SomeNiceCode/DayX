namespace DayX.Database.Catalog
{
    public class Category 
    {
         Guid Id { get; set; }
        string Name { get; set; }
         ICollection<CategoryAttribute> Attributes { get; set; }
    }
    
    
    
    
    
    
}
