namespace DayX.Database.Catalog
{
    /// <summary>
    /// Представляет значение атрибута, присвоенное конкретному продукту.
    /// Например: "Цвет = Красный", "Размер = XL".
    /// </summary>
    public class ProductAttributeValue
    {
        /// <summary>
        /// Уникальный идентификатор значения атрибута.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Идентификатор продукта, к которому относится значение.
        /// </summary>
        public Guid ProductId { get; private set; }

        /// <summary>
        /// Идентификатор атрибута категории, определяющего тип значения.
        /// </summary>
        public Guid CategoryAttributeId { get; private set; }

        /// <summary>
        /// Значение атрибута (например, "Красный", "XL").
        /// </summary>
        public string Value { get; private set; } = null!;

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private ProductAttributeValue() { }

        /// <summary>
        /// Создаёт новое значение атрибута для продукта.
        /// </summary>
        /// <param name="productId">Идентификатор продукта.</param>
        /// <param name="categoryAttributeId">Идентификатор атрибута категории.</param>
        /// <param name="value">Значение атрибута.</param>
        /// <returns>Новый экземпляр ProductAttributeValue.</returns>
        public static ProductAttributeValue Create(Guid productId, Guid categoryAttributeId, string value)
        {
            if (productId == Guid.Empty)
                throw new ArgumentException("Product ID cannot be empty.");

            if (categoryAttributeId == Guid.Empty)
                throw new ArgumentException("CategoryAttribute ID cannot be empty.");

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Attribute value cannot be empty.");

            return new ProductAttributeValue
            {
                Id = Guid.NewGuid(),
                ProductId = productId,
                CategoryAttributeId = categoryAttributeId,
                Value = value
            };
        }
    }
}

