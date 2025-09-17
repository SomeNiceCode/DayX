using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Admin;

namespace DayX.Infrastructure.Configurations.Admin
{
    /// <summary>
    /// Конфигурация сущности <see cref="AuditLog"/> для EF Core.
    /// Определяет ключи, ограничения, индексы и связи для таблицы аудита действий администраторов.
    /// </summary>
    public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
    {
        /// <summary>
        /// Настраивает модель <see cref="AuditLog"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="AuditLog"/>.</param>
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(a => a.Id);

            /// <summary>
            /// Настройка поля Action — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(a => a.Action)
                   .IsRequired()
                   .HasMaxLength(100);

            /// <summary>
            /// Настройка поля Entity — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(a => a.Entity)
                   .IsRequired()
                   .HasMaxLength(100);

            /// <summary>
            /// Настройка поля EntityId — опциональное.
            /// </summary>
            builder.Property(a => a.EntityId)
                   .IsRequired(false);

            /// <summary>
            /// Настройка поля AdminUserId — обязательное.
            /// </summary>
            builder.Property(a => a.AdminUserId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля Timestamp — обязательное.
            /// </summary>
            builder.Property(a => a.Timestamp)
                   .IsRequired();

            /// <summary>
            /// Связь с AdminUser (многие к одному).
            /// </summary>
            builder.HasOne<AdminUser>()
                   .WithMany()
                   .HasForeignKey(a => a.AdminUserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
