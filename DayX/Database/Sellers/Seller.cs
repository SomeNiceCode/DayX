using DayX.Database.Catalog;
using DayX.Database.Marketing;

namespace DayX.Database.Sellers
{
    /// <summary>
    /// Продавец маркетплейса — владелец товаров и скидок.
    /// </summary>
    public class Seller
    {
        // Приватные коллекции для инкапсуляции
        private readonly List<Product> _products = new();
        private readonly List<Discount> _discounts = new();

        /// <summary>
        /// Уникальный идентификатор продавца.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Идентификатор пользователя, которому принадлежит продавец.
        /// Может быть null, если продавец — юрлицо без личного аккаунта.
        /// </summary>
        public Guid? UserId { get; private set; }

        /// <summary>
        /// Название магазина или компании.
        /// </summary>
        public string Name { get; private set; } = null!;

        /// <summary>
        /// Дата регистрации продавца.
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Коллекция товаров, принадлежащих продавцу.
        /// </summary>
        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

        /// <summary>
        /// Коллекция скидок, назначенных продавцом.
        /// </summary>
        public IReadOnlyCollection<Discount> Discounts => _discounts.AsReadOnly();

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private Seller() { }

        /// <summary>
        /// Создаёт нового продавца.
        /// </summary>
        public static Seller Create(Guid? userId, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Seller name cannot be empty.");

            return new Seller
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Name = name,
                CreatedAt = DateTime.UtcNow
            };
        }

        /// <summary>
        /// Добавляет товар в коллекцию продавца.
        /// </summary>
        public void AddProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (product.SellerId != Id)
                throw new InvalidOperationException("Product's SellerId does not match this seller.");

            _products.Add(product);
        }

        /// <summary>
        /// Добавляет скидку в коллекцию продавца.
        /// </summary>
        public void AddDiscount(Discount discount)
        {
            if (discount == null) throw new ArgumentNullException(nameof(discount));
            if (discount.SellerId != Id)
                throw new InvalidOperationException("Discount's SellerId does not match this seller.");

            _discounts.Add(discount);
        }
    }
}
