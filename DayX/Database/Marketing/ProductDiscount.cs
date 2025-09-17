namespace DayX.Database.Marketing
{
    /// <summary>
    /// Представляет связь между продуктом и скидкой.
    /// Используется для назначения маркетинговых предложений конкретным товарам.
    /// </summary>
    public class ProductDiscount
    {
        /// <summary>
        /// Идентификатор продукта, к которому применяется скидка.
        /// </summary>
        public Guid ProductId { get; private set; }

        /// <summary>
        /// Идентификатор скидки, применяемой к продукту.
        /// </summary>
        public Guid DiscountId { get; private set; }

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private ProductDiscount() { }

        /// <summary>
        /// Создаёт новую связь между продуктом и скидкой.
        /// </summary>
        /// <param name="productId">Идентификатор продукта.</param>
        /// <param name="discountId">Идентификатор скидки.</param>
        /// <returns>Новый экземпляр ProductDiscount.</returns>
        public static ProductDiscount Create(Guid productId, Guid discountId)
        {
            if (productId == Guid.Empty)
                throw new ArgumentException("Product ID cannot be empty.");

            if (discountId == Guid.Empty)
                throw new ArgumentException("Discount ID cannot be empty.");

            return new ProductDiscount
            {
                ProductId = productId,
                DiscountId = discountId
            };
        }
    }
}

