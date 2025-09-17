using DayX.Database.Orders;
using DayX.Database.Reviews;

namespace DayX.Database.Users
{
    /// <summary>
    /// Представляет пользователя маркетплейса, включая контактные данные, адреса, заказы и отзывы.
    /// </summary>
    public class User
    {
        private readonly List<UserAddress> _addresses = new();
        private readonly List<FavoriteProduct> _favorites = new();
        private readonly List<Review> _reviews = new();
        private readonly List<Order> _orders = new();

        /// <summary>
        /// Уникальный идентификатор пользователя.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Email пользователя.
        /// </summary>
        public string Email { get; private set; } = null!;

        /// <summary>
        /// Хэш пароля пользователя.
        /// </summary>
        public string PasswordHash { get; private set; } = null!;

        /// <summary>
        /// Коллекция адресов пользователя.
        /// </summary>
        public IReadOnlyCollection<UserAddress> Addresses => _addresses.AsReadOnly();

        /// <summary>
        /// Коллекция заказов пользователя.
        /// </summary>
        public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();

        /// <summary>
        /// Коллекция избранных товаров пользователя.
        /// </summary>
        public IReadOnlyCollection<FavoriteProduct> Favorites => _favorites.AsReadOnly();

        /// <summary>
        /// Коллекция отзывов пользователя.
        /// </summary>
        public IReadOnlyCollection<Review> Reviews => _reviews.AsReadOnly();

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private User() { }

        /// <summary>
        /// Создаёт нового пользователя.
        /// </summary>
        /// <param name="email">Email пользователя.</param>
        /// <param name="passwordHash">Хэш пароля.</param>
        /// <returns>Новый экземпляр пользователя.</returns>
        public static User Create(string email, string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty.");

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Password hash cannot be empty.");

            return new User
            {
                Id = Guid.NewGuid(),
                Email = email,
                PasswordHash = passwordHash
            };
        }

        /// <summary>
        /// Добавляет адрес пользователю.
        /// </summary>
        /// <param name="address">Адрес пользователя.</param>
        public void AddAddress(UserAddress address)
        {
            if (address == null) throw new ArgumentNullException(nameof(address));
            _addresses.Add(address);
        }

        /// <summary>
        /// Добавляет товар в избранное.
        /// </summary>
        /// <param name="favorite">Избранный товар.</param>
        public void AddFavorite(FavoriteProduct favorite)
        {
            if (favorite == null) throw new ArgumentNullException(nameof(favorite));
            _favorites.Add(favorite);
        }

        /// <summary>
        /// Добавляет отзыв пользователя.
        /// </summary>
        /// <param name="review">Отзыв.</param>
        public void AddReview(Review review)
        {
            if (review == null) throw new ArgumentNullException(nameof(review));
            _reviews.Add(review);
        }

        /// <summary>
        /// Добавляет заказ пользователя.
        /// </summary>
        /// <param name="order">Заказ.</param>
        public void AddOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            _orders.Add(order);
        }
    }
}