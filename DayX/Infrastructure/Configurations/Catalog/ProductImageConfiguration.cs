using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Catalog;

namespace DayX.Infrastructure.Configurations.Catalog
{
    /// <summary>
    /// Конфигурация сущности <see cref="ProductImage"/> для EF Core.
    /// Определяет ключи, ограничения и связи для таблицы изображений продуктов.
    /// </summary>
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        /// <summary>
        /// Настраивает модель <see cref="ProductImage"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="ProductImage"/>.</param>
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(pi => pi.Id);

            /// <summary>
            /// Настройка поля ProductId — обязательное.
            /// </summary>
            builder.Property(pi => pi.ProductId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля Url — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(pi => pi.Url)
                   .IsRequired()
                   .HasMaxLength(1000);

            /// <summary>
            /// Настройка поля Order — обязательное.
            /// </summary>
            builder.Property(pi => pi.Order)
                   .IsRequired();

            /// <summary>
            /// Связь с продуктом (многие к одному).
            /// </summary>
            builder.HasOne<Product>()
                   .WithMany(p => p.Images)
                   .HasForeignKey(pi => pi.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

