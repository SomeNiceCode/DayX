using DayX.Database.Sellers;

namespace DayX.Database.Marketing
{
    /// <summary>
    /// Скидка, назначаемая продавцом на свои товары.
    /// </summary>
    public class Discount
    {
        /// <summary>
        /// Уникальный идентификатор скидки.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Заголовок или краткое описание скидки.
        /// </summary>
        public string Title { get; private set; } = null!;

        /// <summary>
        /// Процент скидки (0–100).
        /// </summary>
        public decimal Percentage { get; private set; }

        /// <summary>
        /// Дата начала действия скидки.
        /// </summary>
        public DateTime StartDate { get; private set; }

        /// <summary>
        /// Дата окончания действия скидки.
        /// </summary>
        public DateTime EndDate { get; private set; }

        /// <summary>
        /// Идентификатор продавца, которому принадлежит скидка.
        /// </summary>
        public Guid SellerId { get; private set; }

        /// <summary>
        /// Навигационное свойство для продавца.
        /// </summary>
        public Seller Seller { get; private set; } = null!;

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private Discount() { }

        /// <summary>
        /// Создаёт новую скидку, привязанную к конкретному продавцу.
        /// </summary>
        public static Discount Create(string title, decimal percentage, DateTime startDate, DateTime endDate, Guid sellerId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Discount title cannot be empty.");

            if (percentage <= 0 || percentage > 100)
                throw new ArgumentException("Percentage must be between 0 and 100.");

            if (endDate <= startDate)
                throw new ArgumentException("End date must be after start date.");

            if (sellerId == Guid.Empty)
                throw new ArgumentException("Invalid seller ID.");

            return new Discount
            {
                Id = Guid.NewGuid(),
                Title = title,
                Percentage = percentage,
                StartDate = startDate,
                EndDate = endDate,
                SellerId = sellerId
            };
        }

        /// <summary>
        /// Обновляет параметры скидки.
        /// </summary>
        public void Update(string title, decimal percentage, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Discount title cannot be empty.");

            if (percentage <= 0 || percentage > 100)
                throw new ArgumentException("Percentage must be between 0 and 100.");

            if (endDate <= startDate)
                throw new ArgumentException("End date must be after start date.");

            Title = title;
            Percentage = percentage;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
