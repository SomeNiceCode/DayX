namespace DayX.Database.Admin
{
    /// <summary>
    /// Представляет административного пользователя системы.
    /// Используется для доступа к административным функциям.
    /// </summary>
    public class AdminUser
    {
        /// <summary>
        /// Уникальный идентификатор администратора.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Email администратора, используемый для входа.
        /// </summary>
        public string Email { get; private set; } = null!;

        /// <summary>
        /// Хэш пароля администратора.
        /// </summary>
        public string PasswordHash { get; private set; } = null!;

        /// <summary>
        /// Роль администратора (например, "SuperAdmin", "Moderator").
        /// </summary>
        public string Role { get; private set; } = null!;

        /// <summary>
        /// Приватный конструктор для EF Core.
        /// </summary>
        private AdminUser() { }

        /// <summary>
        /// Создаёт нового административного пользователя.
        /// </summary>
        /// <param name="email">Email администратора.</param>
        /// <param name="passwordHash">Хэш пароля.</param>
        /// <param name="role">Роль администратора.</param>
        /// <returns>Новый экземпляр AdminUser.</returns>
        public static AdminUser Create(string email, string passwordHash, string role)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty.");

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Password hash cannot be empty.");

            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentException("Role cannot be empty.");

            return new AdminUser
            {
                Id = Guid.NewGuid(),
                Email = email,
                PasswordHash = passwordHash,
                Role = role
            };
        }
    }
}

