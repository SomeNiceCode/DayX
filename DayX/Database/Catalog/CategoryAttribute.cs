namespace DayX.Database.Catalog
{
    public class CategoryAttribute 

    { 
        Guid Id { get; set; }
        Guid CategoryId { get; set; }
        string Name { get; set; }
        string DataType { get; set; }
        bool IsRequired { get; set; }
        bool IsFilterable { get; set; }
    }

}
