namespace DayX.Database.PayDelivery
{
    /// <summary>
    /// Представляет способ доставки, включая название, цену и ожидаемое время.
    /// </summary>
    public class DeliveryMethod
    {
        /// <summary>
        /// Уникальный идентификатор метода доставки.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Название метода доставки (например, "Курьер", "Самовывоз").
        /// </summary>
        public string Name { get; private set; } = null!;

        /// <summary>
        /// Стоимость доставки.
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Ожидаемое время доставки.
        /// </summary>
        public TimeSpan EstimatedTime { get; private set; }

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private DeliveryMethod() { }

        /// <summary>
        /// Создаёт новый метод доставки.
        /// </summary>
        /// <param name="name">Название метода.</param>
        /// <param name="price">Стоимость доставки.</param>
        /// <param name="estimatedTime">Ожидаемое время доставки.</param>
        /// <returns>Новый экземпляр DeliveryMethod.</returns>
        public static DeliveryMethod Create(string name, decimal price, TimeSpan estimatedTime)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Delivery method name cannot be empty.");

            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");

            if (estimatedTime.TotalMinutes <= 0)
                throw new ArgumentOutOfRangeException(nameof(estimatedTime), "Estimated time must be positive.");

            return new DeliveryMethod
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = price,
                EstimatedTime = estimatedTime
            };
        }
    }
}


