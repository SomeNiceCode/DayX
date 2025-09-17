using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.PayDelivery;
using DayX.Database.Orders;

namespace DayX.Infrastructure.Configurations.PayDelivery
{
    /// <summary>
    /// Конфигурация сущности <see cref="Shipment"/> для EF Core.
    /// Определяет ключи, ограничения и связи для таблицы доставок заказов.
    /// </summary>
    public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
    {
        /// <summary>
        /// Настраивает модель <see cref="Shipment"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="Shipment"/>.</param>
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(s => s.Id);

            /// <summary>
            /// Настройка поля OrderId — обязательное.
            /// </summary>
            builder.Property(s => s.OrderId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля TrackingNumber — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(s => s.TrackingNumber)
                   .IsRequired()
                   .HasMaxLength(100);

            /// <summary>
            /// Настройка поля ShippedAt — опциональное.
            /// </summary>
            builder.Property(s => s.ShippedAt)
                   .IsRequired(false);

            /// <summary>
            /// Настройка поля DeliveredAt — опциональное.
            /// </summary>
            builder.Property(s => s.DeliveredAt)
                   .IsRequired(false);

            /// <summary>
            /// Настройка поля DeliveryMethodId — обязательное.
            /// </summary>
            builder.Property(s => s.DeliveryMethodId)
                   .IsRequired();

            /// <summary>
            /// Связь с заказом (один заказ — одна доставка).
            /// </summary>
            builder.HasOne<Order>()
                   .WithOne(o => o.Shipment)
                   .HasForeignKey<Shipment>(s => s.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Связь с методом доставки (многие доставки — один метод).
            /// </summary>
            builder.HasOne<DeliveryMethod>()
                   .WithMany()
                   .HasForeignKey(s => s.DeliveryMethodId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

