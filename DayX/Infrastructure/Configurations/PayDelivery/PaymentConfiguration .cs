using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.PayDelivery;
using DayX.Database.Orders;

namespace DayX.Infrastructure.Configurations.PayDelivery
{
    /// <summary>
    /// Конфигурация сущности <see cref="Payment"/> для EF Core.
    /// Определяет ключи, ограничения и связи для таблицы оплат заказов.
    /// </summary>
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        /// <summary>
        /// Настраивает модель <see cref="Payment"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="Payment"/>.</param>
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(p => p.Id);

            /// <summary>
            /// Настройка поля OrderId — обязательное.
            /// </summary>
            builder.Property(p => p.OrderId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля Provider — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(p => p.Provider)
                   .IsRequired()
                   .HasMaxLength(100);

            /// <summary>
            /// Настройка поля Status — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(p => p.Status)
                   .IsRequired()
                   .HasMaxLength(50);

            /// <summary>
            /// Настройка поля PaidAt — опциональное.
            /// </summary>
            builder.Property(p => p.PaidAt)
                   .IsRequired(false);

            /// <summary>
            /// Связь с заказом (один заказ — одна оплата).
            /// </summary>
            builder.HasOne<Order>()
                   .WithOne(o => o.Payment)
                   .HasForeignKey<Payment>(p => p.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}