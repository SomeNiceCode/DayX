using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Carts;
using DayX.Database.Stock;

namespace DayX.Infrastructure.Configurations.Carts
{
    /// <summary>
    /// Конфигурация сущности <see cref="CartItem"/> для EF Core.
    /// Определяет ключи, ограничения и связи для таблицы элементов корзины.
    /// </summary>
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        /// <summary>
        /// Настраивает модель <see cref="CartItem"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="CartItem"/>.</param>
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(ci => ci.Id);

            /// <summary>
            /// Настройка поля CartId — обязательное.
            /// </summary>
            builder.Property(ci => ci.CartId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля ProductVariantId — обязательное.
            /// </summary>
            builder.Property(ci => ci.ProductVariantId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля Quantity — обязательное.
            /// </summary>
            builder.Property(ci => ci.Quantity)
                   .IsRequired();

            /// <summary>
            /// Связь с корзиной (многие к одному).
            /// </summary>
            builder.HasOne<Cart>()
                   .WithMany(c => c.Items)
                   .HasForeignKey(ci => ci.CartId)
                   .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Связь с вариантом продукта (многие к одному).
            /// </summary>
            builder.HasOne<ProductVariant>()
                   .WithMany()
                   .HasForeignKey(ci => ci.ProductVariantId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
