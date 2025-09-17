namespace DayX.Database.Admin
{
    /// <summary>
    /// Представляет запись аудита действия администратора.
    /// Используется для отслеживания изменений и операций в системе.
    /// </summary>
    public class AuditLog
    {
        /// <summary>
        /// Уникальный идентификатор записи аудита.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Название действия (например, "Create", "Update", "Delete").
        /// </summary>
        public string Action { get; private set; } = null!;

        /// <summary>
        /// Название сущности, над которой выполнено действие (например, "Product", "User").
        /// </summary>
        public string Entity { get; private set; } = null!;

        /// <summary>
        /// Идентификатор сущности, если применимо.
        /// </summary>
        public Guid? EntityId { get; private set; }

        /// <summary>
        /// Идентификатор администратора, выполнившего действие.
        /// </summary>
        public Guid AdminUserId { get; private set; }

        /// <summary>
        /// Временная метка выполнения действия.
        /// </summary>
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private AuditLog() { }

        /// <summary>
        /// Создаёт новую запись аудита.
        /// </summary>
        /// <param name="action">Тип действия.</param>
        /// <param name="entity">Название сущности.</param>
        /// <param name="entityId">Идентификатор сущности (опционально).</param>
        /// <param name="adminUserId">Идентификатор администратора.</param>
        /// <returns>Новый экземпляр AuditLog.</returns>
        public static AuditLog Create(string action, string entity, Guid? entityId, Guid adminUserId)
        {
            if (string.IsNullOrWhiteSpace(action))
                throw new ArgumentException("Action cannot be empty.");

            if (string.IsNullOrWhiteSpace(entity))
                throw new ArgumentException("Entity name cannot be empty.");

            if (adminUserId == Guid.Empty)
                throw new ArgumentException("AdminUserId cannot be empty.");

            return new AuditLog
            {
                Id = Guid.NewGuid(),
                Action = action,
                Entity = entity,
                EntityId = entityId,
                AdminUserId = adminUserId,
                Timestamp = DateTime.UtcNow
            };
        }
    }
}

