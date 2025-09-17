using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Admin;
using DayX.Database.Users;

namespace DayX.Infrastructure.Configurations.Admin
{
    /// <summary>
    /// Конфигурация сущности <see cref="Notification"/> для EF Core.
    /// Определяет ключи, ограничения, индексы и связи для таблицы уведомлений.
    /// </summary>
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        /// <summary>
        /// Настраивает модель <see cref="Notification"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="Notification"/>.</param>
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(n => n.Id);

            /// <summary>
            /// Настройка поля UserId — обязательное.
            /// </summary>
            builder.Property(n => n.UserId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля Message — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(n => n.Message)
                   .IsRequired()
                   .HasMaxLength(1000);

            /// <summary>
            /// Настройка поля IsRead — обязательное.
            /// </summary>
            builder.Property(n => n.IsRead)
                   .IsRequired();

            /// <summary>
            /// Настройка поля CreatedAt — обязательное.
            /// </summary>
            builder.Property(n => n.CreatedAt)
                   .IsRequired();

            /// <summary>
            /// Связь с User (многие к одному).
            /// </summary>
            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(n => n.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
