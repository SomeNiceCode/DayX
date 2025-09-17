namespace DayX.Database.Catalog
{
    /// <summary>
    /// Представляет товар в маркетплейсе, включая базовые данные, изображения, атрибуты, теги и владельца (продавца).
    /// </summary>
    public class Product
    {
        // Приватные коллекции для инкапсуляции
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
        /// Идентификатор продавца, которому принадлежит продукт.
        /// </summary>
        public Guid SellerId { get; private set; }

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
        /// <param name="sellerId">Идентификатор продавца.</param>
        /// <returns>Созданный экземпляр Product.</returns>
        public static Product Create(string title, string description, Guid categoryId, Guid sellerId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Product title cannot be empty.");

            if (categoryId == Guid.Empty)
                throw new ArgumentException("Invalid category ID.");

            if (sellerId == Guid.Empty)
                throw new ArgumentException("Invalid seller ID.");

            return new Product
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                CategoryId = categoryId,
                SellerId = sellerId
            };
        }

        /// <summary>
        /// Обновляет название продукта.
        /// </summary>
        public void UpdateTitle(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("Product title cannot be empty.");

            Title = newTitle;
        }

        /// <summary>
        /// Обновляет описание продукта.
        /// </summary>
        public void UpdateDescription(string newDescription)
        {
            Description = newDescription;
        }

        /// <summary>
        /// Назначает новую категорию продукту.
        /// </summary>
        public void AssignCategory(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
                throw new ArgumentException("Invalid category ID.");

            CategoryId = categoryId;
        }

        /// <summary>
        /// Назначает нового продавца продукту.
        /// </summary>
        public void AssignSeller(Guid sellerId)
        {
            if (sellerId == Guid.Empty)
                throw new ArgumentException("Invalid seller ID.");

            SellerId = sellerId;
        }

        /// <summary>
        /// Добавляет атрибут к продукту.
        /// </summary>
        public void AddAttributeValue(ProductAttributeValue value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            _attributeValues.Add(value);
        }

        /// <summary>
        /// Добавляет изображение к продукту.
        /// </summary>
        public void AddImage(ProductImage image)
        {
            if (image == null) throw new ArgumentNullException(nameof(image));
            _images.Add(image);
        }

        /// <summary>
        /// Добавляет тег к продукту.
        /// </summary>
        public void AddTag(ProductTag tag)
        {
            if (tag == null) throw new ArgumentNullException(nameof(tag));
            _tags.Add(tag);
        }
    }
}
