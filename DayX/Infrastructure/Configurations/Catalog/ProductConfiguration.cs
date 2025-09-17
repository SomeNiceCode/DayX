using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Catalog;
using DayX.Database.Sellers;

namespace DayX.Infrastructure.Configurations.Catalog
{
    /// <summary>
    /// Конфигурация сущности <see cref="Product"/> для EF Core.
    /// Определяет ключи, ограничения и связи для таблицы товаров.
    /// </summary>
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        /// <summary>
        /// Настраивает модель <see cref="Product"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="Product"/>.</param>
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(p => p.Id);

            /// <summary>
            /// Настройка поля Title — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(p => p.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            /// <summary>
            /// Настройка поля Description — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(p => p.Description)
                   .IsRequired()
                   .HasMaxLength(2000);

            /// <summary>
            /// Настройка поля CategoryId — обязательное.
            /// </summary>
            builder.Property(p => p.CategoryId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля SellerId — обязательное.
            /// </summary>
            builder.Property(p => p.SellerId)
                   .IsRequired();

            /// <summary>
            /// Связь с категорией (многие к одному).
            /// </summary>
            builder.HasOne<Category>()
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            /// <summary>
            /// Связь с продавцом (многие к одному).
            /// </summary>
            builder.HasOne<Seller>()
                   .WithMany(s => s.Products)
                   .HasForeignKey(p => p.SellerId)
                   .OnDelete(DeleteBehavior.Restrict);

            /// <summary>
            /// Связь с атрибутами продукта (один продукт — много значений атрибутов).
            /// </summary>
            builder.HasMany(p => p.AttributeValues)
                   .WithOne()
                   .HasForeignKey("ProductId")
                   .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Связь с изображениями продукта (один продукт — много изображений).
            /// </summary>
            builder.HasMany(p => p.Images)
                   .WithOne()
                   .HasForeignKey("ProductId")
                   .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Связь с тегами продукта (один продукт — много тегов).
            /// </summary>
            builder.HasMany(p => p.Tags)
                   .WithOne()
                   .HasForeignKey("ProductId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
