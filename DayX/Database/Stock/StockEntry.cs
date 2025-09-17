namespace DayX.Database.Stock
{
    /// <summary>
    /// Представляет запись об изменении количества товара на складе, включая причину и временную метку.
    /// </summary>
    public class StockEntry
    {
        /// <summary>
        /// Уникальный идентификатор записи.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Идентификатор варианта продукта, к которому относится изменение.
        /// </summary>
        public Guid ProductVariantId { get; private set; }

        /// <summary>
        /// Изменение количества (может быть положительным или отрицательным).
        /// </summary>
        public int QuantityChange { get; private set; }

        /// <summary>
        /// Временная метка, когда было зафиксировано изменение.
        /// </summary>
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// Причина изменения (например, "Поставка", "Возврат", "Продажа").
        /// </summary>
        public string Reason { get; private set; } = null!;

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private StockEntry() { }

        /// <summary>
        /// Создаёт новую запись об изменении количества на складе.
        /// </summary>
        /// <param name="productVariantId">Идентификатор варианта продукта.</param>
        /// <param name="quantityChange">Изменение количества.</param>
        /// <param name="reason">Причина изменения.</param>
        /// <returns>Новая запись StockEntry.</returns>
        public static StockEntry Create(Guid productVariantId, int quantityChange, string reason)
        {
            if (productVariantId == Guid.Empty)
                throw new ArgumentException("ProductVariant ID cannot be empty.");

            if (string.IsNullOrWhiteSpace(reason))
                throw new ArgumentException("Reason cannot be empty.");

            return new StockEntry
            {
                Id = Guid.NewGuid(),
                ProductVariantId = productVariantId,
                QuantityChange = quantityChange,
                Reason = reason,
                Timestamp = DateTime.UtcNow
            };
        }
    }
}

