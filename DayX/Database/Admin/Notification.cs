namespace DayX.Database.Admin
{
    /// <summary>
    /// Представляет уведомление, отправленное пользователю.
    /// Используется для отображения системных сообщений.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Уникальный идентификатор уведомления.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Идентификатор пользователя, которому адресовано уведомление.
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// Текст уведомления.
        /// </summary>
        public string Message { get; private set; } = null!;

        /// <summary>
        /// Статус прочтения уведомления.
        /// </summary>
        public bool IsRead { get; private set; }

        /// <summary>
        /// Дата и время создания уведомления.
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private Notification() { }

        /// <summary>
        /// Создаёт новое уведомление.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="message">Текст уведомления.</param>
        /// <returns>Новый экземпляр Notification.</returns>
        public static Notification Create(Guid userId, string message)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("User ID cannot be empty.");

            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message cannot be empty.");

            return new Notification
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Message = message,
                IsRead = false,
                CreatedAt = DateTime.UtcNow
            };
        }

        /// <summary>
        /// Помечает уведомление как прочитанное.
        /// </summary>
        public void MarkAsRead()
        {
            IsRead = true;
        }
    }
}

