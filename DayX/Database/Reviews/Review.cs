namespace DayX.Database.Reviews
{
    /// <summary>
    /// Представляет отзыв пользователя о продукте, включая комментарий, рейтинг и дату создания.
    /// </summary>
    public class Review
    {
        /// <summary>
        /// Уникальный идентификатор отзыва.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Идентификатор продукта, к которому относится отзыв.
        /// </summary>
        public Guid ProductId { get; private set; }

        /// <summary>
        /// Идентификатор пользователя, оставившего отзыв.
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// Текстовый комментарий пользователя.
        /// </summary>
        public string Comment { get; private set; } = null!;

        /// <summary>
        /// Оценка продукта по шкале от 1 до 5.
        /// </summary>
        public int Rating { get; private set; }

        /// <summary>
        /// Дата и время создания отзыва.
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private Review() { }

        /// <summary>
        /// Создаёт новый отзыв.
        /// </summary>
        /// <param name="productId">Идентификатор продукта.</param>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="comment">Комментарий.</param>
        /// <param name="rating">Оценка от 1 до 5.</param>
        /// <returns>Новый экземпляр отзыва.</returns>
        public static Review Create(Guid productId, Guid userId, string comment, int rating)
        {
            if (productId == Guid.Empty)
                throw new ArgumentException("Product ID cannot be empty.");

            if (userId == Guid.Empty)
                throw new ArgumentException("User ID cannot be empty.");

            if (string.IsNullOrWhiteSpace(comment))
                throw new ArgumentException("Comment cannot be empty.");

            if (rating < 1 || rating > 5)
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating must be between 1 and 5.");

            return new Review
            {
                Id = Guid.NewGuid(),
                ProductId = productId,
                UserId = userId,
                Comment = comment,
                Rating = rating,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}

