using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Marketing;
using DayX.Database.Users;

namespace DayX.Infrastructure.Configurations.Marketing
{
    /// <summary>
    /// Конфигурация сущности <see cref="Coupon"/> для EF Core.
    /// Определяет ключи, ограничения, индексы и связи для таблицы купонов.
    /// </summary>
    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        /// <summary>
        /// Настраивает модель <see cref="Coupon"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="Coupon"/>.</param>
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(c => c.Id);

            /// <summary>
            /// Настройка поля Code — обязательное, уникальное, с ограничением длины.
            /// </summary>
            builder.Property(c => c.Code)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasIndex(c => c.Code)
                   .IsUnique();

            /// <summary>
            /// Настройка поля Value — обязательное.
            /// </summary>
            builder.Property(c => c.Value)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            /// <summary>
            /// Настройка поля ExpirationDate — обязательное.
            /// </summary>
            builder.Property(c => c.ExpirationDate)
                   .IsRequired();

            /// <summary>
            /// Настройка поля IsUsed — обязательное.
            /// </summary>
            builder.Property(c => c.IsUsed)
                   .IsRequired();

            /// <summary>
            /// Настройка поля UserId — опциональное.
            /// </summary>
            builder.Property(c => c.UserId)
                   .IsRequired(false);

            /// <summary>
            /// Связь с пользователем (многие купоны могут принадлежать одному пользователю).
            /// </summary>
            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(c => c.UserId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

