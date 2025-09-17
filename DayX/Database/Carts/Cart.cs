namespace DayX.Database.Carts
{
    /// <summary>
    /// Представляет корзину пользователя, содержащую выбранные товары.
    /// </summary>
    public class Cart
    {
        private readonly List<CartItem> _items = new();

        /// <summary>
        /// Уникальный идентификатор корзины.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Идентификатор пользователя, которому принадлежит корзина.
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// Коллекция товаров, добавленных в корзину.
        /// </summary>
        public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private Cart() { }

        /// <summary>
        /// Создаёт новую корзину для пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Новый экземпляр Cart.</returns>
        public static Cart Create(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("User ID cannot be empty.");

            return new Cart
            {
                Id = Guid.NewGuid(),
                UserId = userId
            };
        }

        /// <summary>
        /// Добавляет товар в корзину.
        /// </summary>
        /// <param name="item">Элемент корзины.</param>
        public void AddItem(CartItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _items.Add(item);
        }
    }
}

