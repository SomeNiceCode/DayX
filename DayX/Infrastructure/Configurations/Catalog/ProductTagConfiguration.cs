using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Catalog;

namespace DayX.Infrastructure.Configurations.Catalog
{
    /// <summary>
    /// Конфигурация сущности <see cref="ProductTag"/> для EF Core.
    /// Определяет составной ключ и связи для таблицы связей между продуктами и тегами.
    /// </summary>
    public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
    {
        /// <summary>
        /// Настраивает модель <see cref="ProductTag"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="ProductTag"/>.</param>
        public void Configure(EntityTypeBuilder<ProductTag> builder)
        {
            /// <summary>
            /// Устанавливаем составной первичный ключ (ProductId + TagId).
            /// </summary>
            builder.HasKey(pt => new { pt.ProductId, pt.TagId });

            /// <summary>
            /// Настройка поля ProductId — обязательное.
            /// </summary>
            builder.Property(pt => pt.ProductId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля TagId — обязательное.
            /// </summary>
            builder.Property(pt => pt.TagId)
                   .IsRequired();

            /// <summary>
            /// Связь с продуктом (многие к одному).
            /// </summary>
            builder.HasOne<Product>()
                   .WithMany(p => p.Tags)
                   .HasForeignKey(pt => pt.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Связь с тегом (многие к одному).
            /// </summary>
            builder.HasOne<Tag>()
                   .WithMany()
                   .HasForeignKey(pt => pt.TagId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
