namespace DayX.Database.PayDelivery
{
    /// <summary>
    /// Представляет информацию о доставке заказа, включая трекинг, даты и метод доставки.
    /// </summary>
    public class Shipment
    {
        /// <summary>
        /// Уникальный идентификатор доставки.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Идентификатор заказа, к которому относится доставка.
        /// </summary>
        public Guid OrderId { get; private set; }

        /// <summary>
        /// Трек-номер для отслеживания доставки.
        /// </summary>
        public string TrackingNumber { get; private set; } = null!;

        /// <summary>
        /// Дата и время отправки заказа.
        /// </summary>
        public DateTime ShippedAt { get; private set; }

        /// <summary>
        /// Дата и время доставки заказа (если доставлен).
        /// </summary>
        public DateTime? DeliveredAt { get; private set; }

        /// <summary>
        /// Идентификатор метода доставки.
        /// </summary>
        public Guid DeliveryMethodId { get; private set; }

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private Shipment() { }

        /// <summary>
        /// Создаёт новый объект доставки.
        /// </summary>
        /// <param name="orderId">Идентификатор заказа.</param>
        /// <param name="deliveryMethodId">Идентификатор метода доставки.</param>
        /// <param name="trackingNumber">Трек-номер доставки.</param>
        /// <returns>Новый экземпляр доставки.</returns>
        public static Shipment Create(Guid orderId, Guid deliveryMethodId, string trackingNumber)
        {
            if (orderId == Guid.Empty)
                throw new ArgumentException("Order ID cannot be empty.");

            if (deliveryMethodId == Guid.Empty)
                throw new ArgumentException("Delivery method ID cannot be empty.");

            if (string.IsNullOrWhiteSpace(trackingNumber))
                throw new ArgumentException("Tracking number cannot be empty.");

            return new Shipment
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                DeliveryMethodId = deliveryMethodId,
                TrackingNumber = trackingNumber
            };
        }

        /// <summary>
        /// Помечает доставку как отправленную.
        /// </summary>
        public void MarkAsShipped()
        {
            if (ShippedAt != default)
                throw new InvalidOperationException("Shipment is already marked as shipped.");

            ShippedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Помечает доставку как завершённую.
        /// </summary>
        public void MarkAsDelivered()
        {
            if (ShippedAt == default)
                throw new InvalidOperationException("Cannot deliver before shipment.");

            if (DeliveredAt != null)
                throw new InvalidOperationException("Shipment is already marked as delivered.");

            DeliveredAt = DateTime.UtcNow;
        }
    }
}

