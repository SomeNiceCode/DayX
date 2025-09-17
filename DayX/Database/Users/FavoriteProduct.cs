namespace DayX.Database.Users
{
    /// <summary>
    /// Представляет товар, добавленный пользователем в избранное.
    /// </summary>
    public class FavoriteProduct
    {
        /// <summary>
        /// Уникальный идентификатор записи избранного.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Идентификатор пользователя, добавившего товар в избранное.
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// Идентификатор варианта продукта, добавленного в избранное.
        /// </summary>
        public Guid ProductVariantId { get; private set; }

        /// <summary>
        /// Дата и время добавления товара в избранное.
        /// </summary>
        public DateTime AddedAt { get; private set; }

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private FavoriteProduct() { }

        /// <summary>
        /// Создаёт новую запись избранного товара.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="productVariantId">Идентификатор варианта продукта.</param>
        /// <returns>Новая запись FavoriteProduct.</returns>
        public static FavoriteProduct Create(Guid userId, Guid productVariantId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("User ID cannot be empty.");

            if (productVariantId == Guid.Empty)
                throw new ArgumentException("ProductVariant ID cannot be empty.");

            return new FavoriteProduct
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ProductVariantId = productVariantId,
                AddedAt = DateTime.UtcNow
            };
        }
    }
}

