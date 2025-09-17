namespace DayX.Database.Catalog
{
    /// <summary>
    /// Представляет категорию товаров, включая связанные атрибуты, продукты и теги.
    /// </summary>
    public class Category
    {
        private readonly List<CategoryAttribute> _attributes = new();
        private readonly List<Product> _products = new();
        private readonly List<ProductTag> _tags = new();

        /// <summary>
        /// Уникальный идентификатор категории.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Название категории (например, "Одежда", "Электроника").
        /// </summary>
        public string Name { get; private set; } = null!;

        /// <summary>
        /// Коллекция атрибутов, связанных с категорией.
        /// </summary>
        public IReadOnlyCollection<CategoryAttribute> Attributes => _attributes.AsReadOnly();

        /// <summary>
        /// Коллекция продуктов, принадлежащих категории.
        /// </summary>
        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

        /// <summary>
        /// Коллекция тегов, связанных с категорией.
        /// </summary>
        public IReadOnlyCollection<ProductTag> Tags => _tags.AsReadOnly();

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private Category() { }

        /// <summary>
        /// Создаёт новую категорию.
        /// </summary>
        /// <param name="name">Название категории.</param>
        /// <returns>Новый экземпляр Category.</returns>
        public static Category Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Category name cannot be empty.");

            return new Category
            {
                Id = Guid.NewGuid(),
                Name = name
            };
        }

        /// <summary>
        /// Добавляет атрибут к категории.
        /// </summary>
        /// <param name="attribute">Атрибут категории.</param>
        public void AddAttribute(CategoryAttribute attribute)
        {
            if (attribute == null) throw new ArgumentNullException(nameof(attribute));
            _attributes.Add(attribute);
        }

        /// <summary>
        /// Добавляет продукт в категорию.
        /// </summary>
        /// <param name="product">Продукт.</param>
        public void AddProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            _products.Add(product);
        }

        /// <summary>
        /// Добавляет тег к категории.
        /// </summary>
        /// <param name="tag">Тег.</param>
        public void AddTag(ProductTag tag)
        {
            if (tag == null) throw new ArgumentNullException(nameof(tag));
            _tags.Add(tag);
        }
    }
}
