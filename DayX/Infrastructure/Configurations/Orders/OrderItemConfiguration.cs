using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Orders;
using DayX.Database.Stock;

namespace DayX.Infrastructure.Configurations.Orders
{
    /// <summary>
    /// Конфигурация сущности <see cref="OrderItem"/> для EF Core.
    /// Определяет ключи, ограничения и связи для таблицы позиций заказов.
    /// </summary>
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        /// <summary>
        /// Настраивает модель <see cref="OrderItem"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="OrderItem"/>.</param>
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(oi => oi.Id);

            /// <summary>
            /// Настройка поля OrderId — обязательное.
            /// </summary>
            builder.Property(oi => oi.OrderId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля ProductVariantId — обязательное.
            /// </summary>
            builder.Property(oi => oi.ProductVariantId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля Quantity — обязательное.
            /// </summary>
            builder.Property(oi => oi.Quantity)
                   .IsRequired();

            /// <summary>
            /// Настройка поля UnitPrice — обязательное, decimal(18,2).
            /// </summary>
            builder.Property(oi => oi.UnitPrice)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            /// <summary>
            /// Связь с заказом (многие к одному).
            /// </summary>
            builder.HasOne<Order>()
                   .WithMany(o => o.Items)
                   .HasForeignKey(oi => oi.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Связь с вариантом продукта (многие к одному).
            /// </summary>
            builder.HasOne<ProductVariant>()
                   .WithMany()
                   .HasForeignKey(oi => oi.ProductVariantId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
