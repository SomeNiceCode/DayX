using DayX.Database.PayDelivery;

namespace DayX.Database.Orders
{
    /// <summary>
    /// Представляет заказ пользователя, включая товары, оплату, доставку и статус выполнения.
    /// </summary>
    public class Order
    {
        private readonly List<OrderItem> _items = new();

        /// <summary>
        /// Уникальный идентификатор заказа.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Идентификатор пользователя, разместившего заказ.
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// Дата и время создания заказа.
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Текущий статус заказа.
        /// </summary>
        public OrderStatus Status { get; private set; }

        /// <summary>
        /// Идентификатор адреса доставки.
        /// </summary>
        public Guid AddressId { get; private set; }

        /// <summary>
        /// Коллекция позиций заказа.
        /// </summary>
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

        /// <summary>
        /// Информация об оплате заказа.
        /// </summary>
        public Payment Payment { get; private set; } = null!;

        /// <summary>
        /// Информация о доставке заказа.
        /// </summary>
        public Shipment Shipment { get; private set; } = null!;

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private Order() { }

        /// <summary>
        /// Создаёт новый заказ.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="addressId">Идентификатор адреса доставки.</param>
        /// <returns>Новый экземпляр заказа.</returns>
        public static Order Create(Guid userId, Guid addressId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("User ID cannot be empty.");

            if (addressId == Guid.Empty)
                throw new ArgumentException("Address ID cannot be empty.");

            return new Order
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                AddressId = addressId,
                CreatedAt = DateTime.UtcNow,
                Status = OrderStatus.Pending
            };
        }

        /// <summary>
        /// Добавляет позицию в заказ.
        /// </summary>
        /// <param name="item">Позиция заказа.</param>
        public void AddItem(OrderItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _items.Add(item);
        }

        /// <summary>
        /// Помечает заказ как оплаченный.
        /// </summary>
        public void MarkAsPaid()
        {
            if (Status != OrderStatus.Pending)
                throw new InvalidOperationException("Only pending orders can be marked as paid.");

            Status = OrderStatus.Paid;
        }

        /// <summary>
        /// Отменяет заказ.
        /// </summary>
        public void Cancel()
        {
            if (Status == OrderStatus.Delivered)
                throw new InvalidOperationException("Delivered orders cannot be cancelled.");

            Status = OrderStatus.Cancelled;
        }

        /// <summary>
        /// Помечает заказ как отправленный.
        /// </summary>
        public void Ship()
        {
            if (Status != OrderStatus.Paid)
                throw new InvalidOperationException("Only paid orders can be shipped.");

            Status = OrderStatus.Shipped;
        }

        /// <summary>
        /// Помечает заказ как доставленный.
        /// </summary>
        public void Deliver()
        {
            if (Status != OrderStatus.Shipped)
                throw new InvalidOperationException("Only shipped orders can be delivered.");

            Status = OrderStatus.Delivered;
        }
    }
}
