using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Stock;
using DayX.Database.Catalog;

namespace DayX.Infrastructure.Configurations.Stock
{
    /// <summary>
    /// Конфигурация сущности <see cref="ProductVariant"/> для EF Core.
    /// Определяет ключи, ограничения и связи для таблицы вариантов продуктов.
    /// </summary>
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        /// <summary>
        /// Настраивает модель <see cref="ProductVariant"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="ProductVariant"/>.</param>
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(pv => pv.Id);

            /// <summary>
            /// Настройка поля ProductId — обязательное.
            /// </summary>
            builder.Property(pv => pv.ProductId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля Name — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(pv => pv.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            /// <summary>
            /// Настройка поля Price — обязательное, decimal(18,2).
            /// </summary>
            builder.Property(pv => pv.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            /// <summary>
            /// Настройка поля StockQuantity — обязательное.
            /// </summary>
            builder.Property(pv => pv.StockQuantity)
                   .IsRequired();

            /// <summary>
            /// Связь с продуктом (многие варианты — один продукт).
            /// </summary>
            builder.HasOne<Product>()
                   .WithMany()
                   .HasForeignKey(pv => pv.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Связь с атрибутами варианта (один вариант — много значений атрибутов).
            /// </summary>
            builder.HasMany(pv => pv.AttributeValues)
                   .WithOne()
                   .HasForeignKey("ProductVariantId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

