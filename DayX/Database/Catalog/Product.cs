namespace DayX.Database.Catalog
{
    /// <summary>
    /// Представляет товар в маркетплейсе, включая базовые данные, изображения, атрибуты и теги.
    /// </summary>
    public class Product
    {
        //  Приватные коллекции для инкапсуляции
        private readonly List<ProductAttributeValue> _attributeValues = new();
        private readonly List<ProductImage> _images = new();
        private readonly List<ProductTag> _tags = new();

        /// <summary>
        /// Уникальный идентификатор продукта.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Название продукта.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Описание продукта.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Идентификатор категории, к которой относится продукт.
        /// </summary>
        public Guid CategoryId { get; private set; }

        /// <summary>
        /// Коллекция атрибутов продукта (например, "Материал: Хлопок").
        /// </summary>
        public IReadOnlyCollection<ProductAttributeValue> AttributeValues => _attributeValues.AsReadOnly();

        /// <summary>
        /// Коллекция изображений продукта.
        /// </summary>
        public IReadOnlyCollection<ProductImage> Images => _images.AsReadOnly();

        /// <summary>
        /// Коллекция тегов продукта (например, "Новинка", "Распродажа").
        /// </summary>
        public IReadOnlyCollection<ProductTag> Tags => _tags.AsReadOnly();

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private Product() { }

        /// <summary>
        /// Фабричный метод создания нового продукта.
        /// </summary>
        /// <param name="title">Название продукта.</param>
        /// <param name="description">Описание продукта.</param>
        /// <param name="categoryId">Идентификатор категории.</param>
        /// <returns>Созданный экземпляр Product.</returns>
        public static Product Create(string title, string description, Guid categoryId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Product title cannot be empty.");

            if (categoryId == Guid.Empty)
                throw new ArgumentException("Invalid category ID.");

            return new Product
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                CategoryId = categoryId
            };
        }

        /// <summary>
        /// Обновляет название продукта.
        /// </summary>
        /// <param name="newTitle">Новое название.</param>
        public void UpdateTitle(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("Product title cannot be empty.");

            Title = newTitle;
        }

        /// <summary>
        /// Обновляет описание продукта.
        /// </summary>
        /// <param name="newDescription">Новое описание.</param>
        public void UpdateDescription(string newDescription)
        {
            Description = newDescription;
        }

        /// <summary>
        /// Назначает новую категорию продукту.
        /// </summary>
        /// <param name="categoryId">Идентификатор категории.</param>
        public void AssignCategory(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
                throw new ArgumentException("Invalid category ID.");

            CategoryId = categoryId;
        }

        /// <summary>
        /// Добавляет атрибут к продукту.
        /// </summary>
        /// <param name="value">Атрибут продукта.</param>
        public void AddAttributeValue(ProductAttributeValue value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            _attributeValues.Add(value);
        }

        /// <summary>
        /// Добавляет изображение к продукту.
        /// </summary>
        /// <param name="image">Изображение продукта.</param>
        public void AddImage(ProductImage image)
        {
            if (image == null) throw new ArgumentNullException(nameof(image));
            _images.Add(image);
        }

        /// <summary>
        /// Добавляет тег к продукту.
        /// </summary>
        /// <param name="tag">Тег продукта.</param>
        public void AddTag(ProductTag tag)
        {
            if (tag == null) throw new ArgumentNullException(nameof(tag));
            _tags.Add(tag);
        }
    }

}
