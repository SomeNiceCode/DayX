namespace DayX.Database.Catalog
{
    /// <summary>
    /// Представляет связь между продуктом и тегом.
    /// Используется для построения отношения многие-ко-многим.
    /// </summary>
    public class ProductTag
    {
        /// <summary>
        /// Идентификатор продукта.
        /// </summary>
        public Guid ProductId { get; private set; }

        /// <summary>
        /// Идентификатор тега.
        /// </summary>
        public Guid TagId { get; private set; }

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private ProductTag() { }

        /// <summary>
        /// Создаёт новую связь между продуктом и тегом.
        /// </summary>
        /// <param name="productId">Идентификатор продукта.</param>
        /// <param name="tagId">Идентификатор тега.</param>
        /// <returns>Новый экземпляр ProductTag.</returns>
        public static ProductTag Create(Guid productId, Guid tagId)
        {
            if (productId == Guid.Empty)
                throw new ArgumentException("Product ID cannot be empty.");

            if (tagId == Guid.Empty)
                throw new ArgumentException("Tag ID cannot be empty.");

            return new ProductTag
            {
                ProductId = productId,
                TagId = tagId
            };
        }
    }
}

