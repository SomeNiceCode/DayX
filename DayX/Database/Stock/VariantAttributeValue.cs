using DayX.Database.Catalog;

namespace DayX.Database.Stock
{
    /// <summary>
    /// Значение атрибута, привязанное к конкретному варианту продукта.
    /// Например: Цвет = Красный, Размер = XL.
    /// </summary>
    public class VariantAttributeValue
    {
        // Конструктор для EF Core
        private VariantAttributeValue() { }

        /// <summary>
        /// Создание нового значения атрибута для варианта.
        /// </summary>
        public VariantAttributeValue(Guid productVariantId, Guid categoryAttributeId, string value)
        {
            Id = Guid.NewGuid();
            ProductVariantId = productVariantId;
            CategoryAttributeId = categoryAttributeId;
            Value = value;
        }

        /// <summary>
        /// Уникальный идентификатор значения атрибута.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Идентификатор варианта продукта.
        /// </summary>
        public Guid ProductVariantId { get; private set; }

        /// <summary>
        /// Идентификатор определённого атрибута категории.
        /// </summary>
        public Guid CategoryAttributeId { get; private set; }

        /// <summary>
        /// Значение атрибута (например, "Красный", "XL").
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Навигационное свойство к варианту продукта.
        /// </summary>
        public ProductVariant ProductVariant { get; private set; } = null!;

        /// <summary>
        /// Навигационное свойство к определению атрибута категории.
        /// </summary>
        public CategoryAttribute CategoryAttribute { get; private set; } = null!;
    }

}
