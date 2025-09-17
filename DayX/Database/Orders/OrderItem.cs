namespace DayX.Database.Orders
{
    /// <summary>
    /// Представляет позицию в заказе, включающую конкретный вариант продукта.
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Уникальный идентификатор позиции заказа.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Идентификатор заказа, к которому относится позиция.
        /// </summary>
        public Guid OrderId { get; private set; }

        /// <summary>
        /// Идентификатор варианта продукта, включённого в заказ.
        /// </summary>
        public Guid ProductVariantId { get; private set; }

        /// <summary>
        /// Количество единиц товара.
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Цена за единицу товара на момент оформления заказа.
        /// </summary>
        public decimal UnitPrice { get; private set; }

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private OrderItem() { }

        /// <summary>
        /// Создаёт новую позицию заказа.
        /// </summary>
        /// <param name="orderId">Идентификатор заказа.</param>
        /// <param name="productVariantId">Идентификатор варианта продукта.</param>
        /// <param name="quantity">Количество товара.</param>
        /// <param name="unitPrice">Цена за единицу.</param>
        /// <returns>Новый экземпляр OrderItem.</returns>
        public static OrderItem Create(Guid orderId, Guid productVariantId, int quantity, decimal unitPrice)
        {
            if (orderId == Guid.Empty)
                throw new ArgumentException("Order ID cannot be empty.");

            if (productVariantId == Guid.Empty)
                throw new ArgumentException("ProductVariant ID cannot be empty.");

            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");

            if (unitPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(unitPrice), "Unit price cannot be negative.");

            return new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                ProductVariantId = productVariantId,
                Quantity = quantity,
                UnitPrice = unitPrice
            };
        }
    }
}

