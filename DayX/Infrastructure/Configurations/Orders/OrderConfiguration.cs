using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Orders;
using DayX.Database.Users;
using DayX.Database.PayDelivery;

namespace DayX.Infrastructure.Configurations.Orders
{
    /// <summary>
    /// Конфигурация сущности <see cref="Order"/> для EF Core.
    /// Определяет ключи, ограничения и связи для таблицы заказов.
    /// </summary>
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        /// <summary>
        /// Настраивает модель <see cref="Order"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="Order"/>.</param>
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(o => o.Id);

            /// <summary>
            /// Настройка поля UserId — обязательное.
            /// </summary>
            builder.Property(o => o.UserId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля CreatedAt — обязательное.
            /// </summary>
            builder.Property(o => o.CreatedAt)
                   .IsRequired();

            /// <summary>
            /// Настройка поля Status — обязательное, хранится как int.
            /// </summary>
            builder.Property(o => o.Status)
                   .IsRequired()
                   .HasConversion<int>();

            /// <summary>
            /// Настройка поля AddressId — обязательное.
            /// </summary>
            builder.Property(o => o.AddressId)
                   .IsRequired();

            /// <summary>
            /// Связь с пользователем (многие заказы — один пользователь).
            /// </summary>
            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(o => o.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            /// <summary>
            /// Связь с элементами заказа (один заказ — много позиций).
            /// </summary>
            builder.HasMany(o => o.Items)
                   .WithOne()
                   .HasForeignKey("OrderId")
                   .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Связь с оплатой (один заказ — одна оплата).
            /// </summary>
            builder.HasOne(o => o.Payment)
                   .WithOne()
                   .HasForeignKey<Payment>("OrderId")
                   .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Связь с доставкой (один заказ — одна доставка).
            /// </summary>
            builder.HasOne(o => o.Shipment)
                   .WithOne()
                   .HasForeignKey<Shipment>("OrderId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
