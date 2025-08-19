namespace DayX.Database.Reviews
{
    public class Review
    {
        Guid Id { get; set; }
        Guid ProductId { get; set; }
        Guid UserId { get; set; }
        string Comment { get; set; }
        int Rating { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
