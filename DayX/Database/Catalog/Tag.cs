namespace DayX.Database.Catalog
{
    /// <summary>
    /// Представляет тег, используемый для классификации или фильтрации продуктов.
    /// Например: "Новинка", "Скидка", "Популярное".
    /// </summary>
    public class Tag
    {
        private readonly List<ProductTag> _productTags = new();

        /// <summary>
        /// Уникальный идентификатор тега.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Название тега.
        /// </summary>
        public string Name { get; private set; } = null!;

        /// <summary>
        /// Коллекция связей между тегом и продуктами.
        /// </summary>
        public IReadOnlyCollection<ProductTag> ProductTags => _productTags.AsReadOnly();

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private Tag() { }

        /// <summary>
        /// Создаёт новый тег.
        /// </summary>
        /// <param name="name">Название тега.</param>
        /// <returns>Новый экземпляр Tag.</returns>
        public static Tag Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Tag name cannot be empty.");

            return new Tag
            {
                Id = Guid.NewGuid(),
                Name = name
            };
        }

        /// <summary>
        /// Добавляет связь между тегом и продуктом.
        /// </summary>
        /// <param name="productTag">Связь ProductTag.</param>
        public void AddProductTag(ProductTag productTag)
        {
            if (productTag == null) throw new ArgumentNullException(nameof(productTag));
            _productTags.Add(productTag);
        }
    }
}
