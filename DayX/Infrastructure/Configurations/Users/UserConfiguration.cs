using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Users;
using DayX.Database.Orders;
using DayX.Database.Reviews;

namespace DayX.Infrastructure.Configurations.Users
{
    /// <summary>
    /// Конфигурация сущности <see cref="User"/> для EF Core.
    /// Определяет ключи, ограничения, индексы и связи для таблицы пользователей.
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Настраивает модель <see cref="User"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="User"/>.</param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(u => u.Id);

            /// <summary>
            /// Настройка поля Email — обязательное, уникальное, с ограничением длины.
            /// </summary>
            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.HasIndex(u => u.Email)
                   .IsUnique();

            /// <summary>
            /// Настройка поля PasswordHash — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(u => u.PasswordHash)
                   .IsRequired()
                   .HasMaxLength(500);

            /// <summary>
            /// Связь с адресами пользователя (один пользователь — много адресов).
            /// </summary>
            builder.HasMany(u => u.Addresses)
                   .WithOne()
                   .HasForeignKey("UserId")
                   .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Связь с заказами пользователя (один пользователь — много заказов).
            /// </summary>
            builder.HasMany(u => u.Orders)
                   .WithOne()
                   .HasForeignKey("UserId")
                   .OnDelete(DeleteBehavior.Restrict);

            /// <summary>
            /// Связь с избранными товарами (один пользователь — много избранных).
            /// </summary>
            builder.HasMany(u => u.Favorites)
                   .WithOne()
                   .HasForeignKey("UserId")
                   .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Связь с отзывами (один пользователь — много отзывов).
            /// </summary>
            builder.HasMany(u => u.Reviews)
                   .WithOne()
                   .HasForeignKey("UserId")
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
