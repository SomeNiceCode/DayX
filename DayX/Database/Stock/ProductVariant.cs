namespace DayX.Database.Stock
{
    /// <summary>
    /// Представляет конкретный вариант продукта (например, размер, цвет, комплектация).
    /// </summary>
    public class ProductVariant
    {
        //  Приватная коллекция атрибутов варианта (например, "Цвет: Красный", "Размер: XL")
        private readonly List<VariantAttributeValue> _attributeValues = new();

        /// <summary>
        /// Уникальный идентификатор варианта.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Идентификатор родительского продукта.
        /// </summary>
        public Guid ProductId { get; private set; }

        /// <summary>
        /// Название варианта (например, "Красный XL").
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Цена варианта.
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Количество товара на складе.
        /// </summary>
        public int StockQuantity { get; private set; }

        /// <summary>
        /// Коллекция атрибутов варианта, доступная только для чтения.
        /// </summary>
        public IReadOnlyCollection<VariantAttributeValue> AttributeValues => _attributeValues.AsReadOnly();

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private ProductVariant() { }

        /// <summary>
        /// Фабричный метод создания нового варианта продукта.
        /// </summary>
        /// <param name="productId">Идентификатор родительского продукта.</param>
        /// <param name="name">Название варианта.</param>
        /// <param name="price">Цена.</param>
        /// <param name="stockQuantity">Количество на складе.</param>
        /// <returns>Созданный экземпляр ProductVariant.</returns>
        public static ProductVariant Create(Guid productId, string name, decimal price, int stockQuantity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Variant name cannot be empty.");

            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");

            if (stockQuantity < 0)
                throw new ArgumentOutOfRangeException(nameof(stockQuantity), "Stock quantity cannot be negative.");

            return new ProductVariant
            {
                Id = Guid.NewGuid(),
                ProductId = productId,
                Name = name,
                Price = price,
                StockQuantity = stockQuantity
            };
        }

        /// <summary>
        /// Обновляет цену варианта.
        /// </summary>
        /// <param name="newPrice">Новая цена.</param>
        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(newPrice), "Price cannot be negative.");

            Price = newPrice;
        }

        /// <summary>
        /// Изменяет количество товара на складе на заданную величину.
        /// </summary>
        /// <param name="delta">Изменение количества (может быть отрицательным).</param>
        public void AdjustStock(int delta)
        {
            var newQuantity = StockQuantity + delta;
            if (newQuantity < 0)
                throw new InvalidOperationException("Stock cannot go below zero.");

            StockQuantity = newQuantity;
        }

        /// <summary>
        /// Добавляет атрибут к варианту (например, "Цвет: Синий").
        /// </summary>
        /// <param name="value">Атрибут варианта.</param>
        public void AddAttributeValue(VariantAttributeValue value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            _attributeValues.Add(value);
        }
    }

}
