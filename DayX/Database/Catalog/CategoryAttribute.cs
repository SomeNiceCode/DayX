namespace DayX.Database.Catalog
{
    /// <summary>
    /// Представляет атрибут категории, определяющий характеристику товаров.
    /// Например: "Цвет", "Размер", "Материал".
    /// </summary>
    public class CategoryAttribute
    {
        /// <summary>
        /// Уникальный идентификатор атрибута.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Идентификатор категории, к которой относится атрибут.
        /// </summary>
        public Guid CategoryId { get; private set; }

        /// <summary>
        /// Название атрибута.
        /// </summary>
        public string Name { get; private set; } = null!;

        /// <summary>
        /// Тип данных атрибута (например, "string", "int", "bool").
        /// </summary>
        public string DataType { get; private set; } = null!;

        /// <summary>
        /// Указывает, является ли атрибут обязательным.
        /// </summary>
        public bool IsRequired { get; private set; }

        /// <summary>
        /// Указывает, может ли атрибут использоваться для фильтрации.
        /// </summary>
        public bool IsFilterable { get; private set; }

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private CategoryAttribute() { }

        /// <summary>
        /// Создаёт новый атрибут категории.
        /// </summary>
        /// <param name="categoryId">Идентификатор категории.</param>
        /// <param name="name">Название атрибута.</param>
        /// <param name="dataType">Тип данных.</param>
        /// <param name="isRequired">Обязательность атрибута.</param>
        /// <param name="isFilterable">Фильтруемость атрибута.</param>
        /// <returns>Новый экземпляр CategoryAttribute.</returns>
        public static CategoryAttribute Create(
            Guid categoryId,
            string name,
            string dataType,
            bool isRequired,
            bool isFilterable)
        {
            if (categoryId == Guid.Empty)
                throw new ArgumentException("Category ID cannot be empty.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Attribute name cannot be empty.");

            if (string.IsNullOrWhiteSpace(dataType))
                throw new ArgumentException("Data type cannot be empty.");

            return new CategoryAttribute
            {
                Id = Guid.NewGuid(),
                CategoryId = categoryId,
                Name = name,
                DataType = dataType,
                IsRequired = isRequired,
                IsFilterable = isFilterable
            };
        }
    }
}

