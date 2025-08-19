namespace DayX.Database.Users
{
    public class UserAddress
    {
        Guid Id { get; set; }
        Guid UserId { get; set; }
        string City { get; set; }
        string Street { get; set; }
        string PostalCode { get; set; }
    }
}
