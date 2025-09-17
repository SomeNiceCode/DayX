using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Admin;

namespace DayX.Infrastructure.Configurations.Admin
{
    /// <summary>
    /// Конфигурация сущности <see cref="AdminUser"/> для EF Core.
    /// Определяет ключи, ограничения и индексы для таблицы административных пользователей.
    /// </summary>
    public class AdminUserConfiguration : IEntityTypeConfiguration<AdminUser>
    {
        /// <summary>
        /// Настраивает модель <see cref="AdminUser"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="AdminUser"/>.</param>
        public void Configure(EntityTypeBuilder<AdminUser> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(a => a.Id);

            /// <summary>
            /// Настройка поля Email — обязательное, уникальное, с ограничением длины.
            /// </summary>
            builder.Property(a => a.Email)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.HasIndex(a => a.Email)
                   .IsUnique();

            /// <summary>
            /// Настройка поля PasswordHash — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(a => a.PasswordHash)
                   .IsRequired()
                   .HasMaxLength(512);

            /// <summary>
            /// Настройка поля Role — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(a => a.Role)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
