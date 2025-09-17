namespace DayX.Database.Catalog
{
    /// <summary>
    /// Представляет изображение, связанное с продуктом.
    /// Используется для визуального отображения товара.
    /// </summary>
    public class ProductImage
    {
        /// <summary>
        /// Уникальный идентификатор изображения.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Идентификатор продукта, к которому относится изображение.
        /// </summary>
        public Guid ProductId { get; private set; }

        /// <summary>
        /// URL-адрес изображения.
        /// </summary>
        public string Url { get; private set; } = null!;

        /// <summary>
        /// Порядок отображения изображения (например, 0 — главное).
        /// </summary>
        public int Order { get; private set; }

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private ProductImage() { }

        /// <summary>
        /// Создаёт новое изображение продукта.
        /// </summary>
        /// <param name="productId">Идентификатор продукта.</param>
        /// <param name="url">URL изображения.</param>
        /// <param name="order">Порядок отображения.</param>
        /// <returns>Новый экземпляр ProductImage.</returns>
        public static ProductImage Create(Guid productId, string url, int order)
        {
            if (productId == Guid.Empty)
                throw new ArgumentException("Product ID cannot be empty.");

            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("Image URL cannot be empty.");

            if (order < 0)
                throw new ArgumentOutOfRangeException(nameof(order), "Order must be non-negative.");

            return new ProductImage
            {
                Id = Guid.NewGuid(),
                ProductId = productId,
                Url = url,
                Order = order
            };
        }
    }
}

