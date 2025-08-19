using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace DayX.Database.Users
{
    public class User
    {
        Guid Id { get; set; }
        string Email { get; set; }
        string PasswordHash { get; set; }
        ICollection<UserAddress> Addresses { get; set; }
        ICollection<Order> Orders { get; set; }
        ICollection<FavoriteProduct> Favorites { get; set; }
        ICollection<Review> Reviews { get; set; }
    }
}
