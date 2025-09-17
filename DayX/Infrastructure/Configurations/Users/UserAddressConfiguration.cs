using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Users;

namespace DayX.Infrastructure.Configurations.Users
{
    /// <summary>
    /// Конфигурация сущности <see cref="UserAddress"/> для EF Core.
    /// Определяет ключи, ограничения и связи для таблицы адресов пользователей.
    /// </summary>
    public class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
    {
        /// <summary>
        /// Настраивает модель <see cref="UserAddress"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="UserAddress"/>.</param>
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(ua => ua.Id);

            /// <summary>
            /// Настройка поля UserId — обязательное.
            /// </summary>
            builder.Property(ua => ua.UserId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля City — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(ua => ua.City)
                   .IsRequired()
                   .HasMaxLength(100);

            /// <summary>
            /// Настройка поля Street — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(ua => ua.Street)
                   .IsRequired()
                   .HasMaxLength(200);

            /// <summary>
            /// Настройка поля PostalCode — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(ua => ua.PostalCode)
                   .IsRequired()
                   .HasMaxLength(20);

            /// <summary>
            /// Связь с пользователем (многие адреса — один пользователь).
            /// </summary>
            builder.HasOne<User>()
                   .WithMany(u => u.Addresses)
                   .HasForeignKey(ua => ua.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

