using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Marketing;
using DayX.Database.Catalog;

namespace DayX.Infrastructure.Configurations.Marketing
{
    /// <summary>
    /// Конфигурация сущности <see cref="ProductDiscount"/> для EF Core.
    /// Определяет составной ключ и связи для таблицы связей между продуктами и скидками.
    /// </summary>
    public class ProductDiscountConfiguration : IEntityTypeConfiguration<ProductDiscount>
    {
        /// <summary>
        /// Настраивает модель <see cref="ProductDiscount"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="ProductDiscount"/>.</param>
        public void Configure(EntityTypeBuilder<ProductDiscount> builder)
        {
            /// <summary>
            /// Устанавливаем составной первичный ключ (ProductId + DiscountId).
            /// </summary>
            builder.HasKey(pd => new { pd.ProductId, pd.DiscountId });

            /// <summary>
            /// Настройка поля ProductId — обязательное.
            /// </summary>
            builder.Property(pd => pd.ProductId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля DiscountId — обязательное.
            /// </summary>
            builder.Property(pd => pd.DiscountId)
                   .IsRequired();

            /// <summary>
            /// Связь с продуктом (многие к одному).
            /// </summary>
            builder.HasOne<Product>()
                   .WithMany()
                   .HasForeignKey(pd => pd.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Связь со скидкой (многие к одному).
            /// </summary>
            builder.HasOne<Discount>()
                   .WithMany()
                   .HasForeignKey(pd => pd.DiscountId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

