namespace DayX.Database.Marketing
{
    /// <summary>
    /// Представляет купон на скидку, который может быть применён пользователем до истечения срока действия.
    /// </summary>
    public class Coupon
    {
        /// <summary>
        /// Уникальный идентификатор купона.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Уникальный код купона, вводимый пользователем.
        /// </summary>
        public string Code { get; private set; } = null!;

        /// <summary>
        /// Сумма скидки, предоставляемая купоном.
        /// </summary>
        public decimal Value { get; private set; }

        /// <summary>
        /// Дата истечения срока действия купона.
        /// </summary>
        public DateTime ExpirationDate { get; private set; }

        /// <summary>
        /// Флаг, указывающий, был ли купон использован.
        /// </summary>
        public bool IsUsed { get; private set; }

        /// <summary>
        /// Идентификатор пользователя, применившего купон (если применён).
        /// </summary>
        public Guid? UserId { get; private set; }

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private Coupon() { }

        /// <summary>
        /// Создаёт новый купон.
        /// </summary>
        /// <param name="code">Код купона.</param>
        /// <param name="value">Сумма скидки.</param>
        /// <param name="expirationDate">Дата истечения срока действия.</param>
        /// <returns>Новый экземпляр купона.</returns>
        public static Coupon Create(string code, decimal value, DateTime expirationDate)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Coupon code cannot be empty.");

            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Coupon value must be positive.");

            if (expirationDate <= DateTime.UtcNow)
                throw new ArgumentException("Expiration date must be in the future.");

            return new Coupon
            {
                Id = Guid.NewGuid(),
                Code = code,
                Value = value,
                ExpirationDate = expirationDate,
                IsUsed = false
            };
        }

        /// <summary>
        /// Помечает купон как использованный и связывает его с пользователем.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        public void MarkAsUsed(Guid userId)
        {
            if (IsUsed)
                throw new InvalidOperationException("Coupon has already been used.");

            if (userId == Guid.Empty)
                throw new ArgumentException("User ID cannot be empty.");

            if (DateTime.UtcNow > ExpirationDate)
                throw new InvalidOperationException("Coupon has expired.");

            IsUsed = true;
            UserId = userId;
        }
    }
}
