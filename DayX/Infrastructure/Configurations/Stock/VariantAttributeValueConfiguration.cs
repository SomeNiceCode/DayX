using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Stock;
using DayX.Database.Catalog;

namespace DayX.Infrastructure.Configurations.Stock
{
    /// <summary>
    /// Конфигурация сущности <see cref="VariantAttributeValue"/> для EF Core.
    /// Определяет ключи, ограничения и связи для таблицы значений атрибутов вариантов продуктов.
    /// </summary>
    public class VariantAttributeValueConfiguration : IEntityTypeConfiguration<VariantAttributeValue>
    {
        /// <summary>
        /// Настраивает модель <see cref="VariantAttributeValue"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="VariantAttributeValue"/>.</param>
        public void Configure(EntityTypeBuilder<VariantAttributeValue> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(vav => vav.Id);

            /// <summary>
            /// Настройка поля ProductVariantId — обязательное.
            /// </summary>
            builder.Property(vav => vav.ProductVariantId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля CategoryAttributeId — обязательное.
            /// </summary>
            builder.Property(vav => vav.CategoryAttributeId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля Value — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(vav => vav.Value)
                   .IsRequired()
                   .HasMaxLength(200);

            /// <summary>
            /// Связь с вариантом продукта (многие значения — один вариант).
            /// </summary>
            builder.HasOne(vav => vav.ProductVariant)
                   .WithMany(pv => pv.AttributeValues)
                   .HasForeignKey(vav => vav.ProductVariantId)
                   .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Связь с атрибутом категории (многие значения — один атрибут).
            /// </summary>
            builder.HasOne(vav => vav.CategoryAttribute)
                   .WithMany()
                   .HasForeignKey(vav => vav.CategoryAttributeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
