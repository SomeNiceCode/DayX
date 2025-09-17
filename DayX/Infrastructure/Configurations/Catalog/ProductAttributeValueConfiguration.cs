using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Catalog;

namespace DayX.Infrastructure.Configurations.Catalog
{
    /// <summary>
    /// Конфигурация сущности <see cref="ProductAttributeValue"/> для EF Core.
    /// Определяет ключи, ограничения и связи для таблицы значений атрибутов продуктов.
    /// </summary>
    public class ProductAttributeValueConfiguration : IEntityTypeConfiguration<ProductAttributeValue>
    {
        /// <summary>
        /// Настраивает модель <see cref="ProductAttributeValue"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="ProductAttributeValue"/>.</param>
        public void Configure(EntityTypeBuilder<ProductAttributeValue> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(pav => pav.Id);

            /// <summary>
            /// Настройка поля ProductId — обязательное.
            /// </summary>
            builder.Property(pav => pav.ProductId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля CategoryAttributeId — обязательное.
            /// </summary>
            builder.Property(pav => pav.CategoryAttributeId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля Value — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(pav => pav.Value)
                   .IsRequired()
                   .HasMaxLength(500);

            /// <summary>
            /// Связь с продуктом (многие к одному).
            /// </summary>
            builder.HasOne<Product>()
                   .WithMany(p => p.AttributeValues)
                   .HasForeignKey(pav => pav.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Связь с атрибутом категории (многие к одному).
            /// </summary>
            builder.HasOne<CategoryAttribute>()
                   .WithMany()
                   .HasForeignKey(pav => pav.CategoryAttributeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
