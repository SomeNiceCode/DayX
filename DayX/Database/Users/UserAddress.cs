namespace DayX.Database.Users
{
    /// <summary>
    /// Представляет адрес пользователя, используемый для доставки заказов.
    /// </summary>
    public class UserAddress
    {
        /// <summary>
        /// Уникальный идентификатор адреса.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Идентификатор пользователя, которому принадлежит адрес.
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// Название города.
        /// </summary>
        public string City { get; private set; } = null!;

        /// <summary>
        /// Название улицы.
        /// </summary>
        public string Street { get; private set; } = null!;

        /// <summary>
        /// Почтовый индекс.
        /// </summary>
        public string PostalCode { get; private set; } = null!;

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private UserAddress() { }

        /// <summary>
        /// Создаёт новый адрес пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="city">Город.</param>
        /// <param name="street">Улица.</param>
        /// <param name="postalCode">Почтовый индекс.</param>
        /// <returns>Новый экземпляр адреса.</returns>
        public static UserAddress Create(Guid userId, string city, string street, string postalCode)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("User ID cannot be empty.");

            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City cannot be empty.");

            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Street cannot be empty.");

            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ArgumentException("Postal code cannot be empty.");

            return new UserAddress
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                City = city,
                Street = street,
                PostalCode = postalCode
            };
        }
    }
}

