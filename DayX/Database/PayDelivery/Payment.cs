namespace DayX.Database.PayDelivery
{
    /// <summary>
    /// Представляет информацию об оплате заказа, включая провайдера, статус и дату оплаты.
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Уникальный идентификатор оплаты.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Идентификатор заказа, к которому относится оплата.
        /// </summary>
        public Guid OrderId { get; private set; }

        /// <summary>
        /// Название платёжного провайдера (например, Stripe, PayPal).
        /// </summary>
        public string Provider { get; private set; } = null!;

        /// <summary>
        /// Статус оплаты (например, "Pending", "Paid", "Failed").
        /// </summary>
        public string Status { get; private set; } = null!;

        /// <summary>
        /// Дата и время успешной оплаты.
        /// </summary>
        public DateTime PaidAt { get; private set; }

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private Payment() { }

        /// <summary>
        /// Создаёт новый объект оплаты.
        /// </summary>
        /// <param name="orderId">Идентификатор заказа.</param>
        /// <param name="provider">Платёжный провайдер.</param>
        /// <returns>Новый экземпляр оплаты.</returns>
        public static Payment Create(Guid orderId, string provider)
        {
            if (orderId == Guid.Empty)
                throw new ArgumentException("Order ID cannot be empty.");

            if (string.IsNullOrWhiteSpace(provider))
                throw new ArgumentException("Provider name cannot be empty.");

            return new Payment
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                Provider = provider,
                Status = "Pending"
            };
        }

        /// <summary>
        /// Помечает оплату как завершённую.
        /// </summary>
        public void MarkAsPaid()
        {
            if (Status == "Paid")
                throw new InvalidOperationException("Payment is already marked as paid.");

            Status = "Paid";
            PaidAt = DateTime.UtcNow;
        }
    }
}
