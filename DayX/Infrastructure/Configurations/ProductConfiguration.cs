using DayX.Database.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DayX.Infrastructure.Configurations
{
    /// <summary>
    /// Конфигурация сущности Product для EF Core.
    /// Настраивает ключи, ограничения, связи и доступ к приватным коллекциям.
    /// </summary>
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //  Первичный ключ
            builder.HasKey(p => p.Id);

            //  Название продукта — обязательное, ограничено по длине
            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(200);

            //  Описание — не обязательно, но ограничено по длине
            builder.Property(p => p.Description)
                .HasMaxLength(1000);

            //  Внешний ключ к категории
            builder.Property(p => p.CategoryId)
                .IsRequired();

            //  Связь с Category (один продукт — одна категория)
            builder.HasOne<Category>()
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); //  Защита от каскадного удаления категории

            //  Коллекция атрибутов
            builder.HasMany<ProductAttributeValue>()
                .WithOne()
                .HasForeignKey("ProductId")
                .OnDelete(DeleteBehavior.Cascade); //  Удаление атрибутов при удалении продукта

            builder.Metadata
                .FindNavigation(nameof(Product.AttributeValues))!
                .SetPropertyAccessMode(PropertyAccessMode.Field); //  Доступ к _attributeValues

            //  Коллекция изображений
            builder.HasMany<ProductImage>()
                .WithOne()
                .HasForeignKey("ProductId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Metadata
                .FindNavigation(nameof(Product.Images))!
                .SetPropertyAccessMode(PropertyAccessMode.Field); //  Доступ к _images

            //  Коллекция тегов
            builder.HasMany<ProductTag>()
                .WithOne()
                .HasForeignKey("ProductId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Metadata
                .FindNavigation(nameof(Product.Tags))!
                .SetPropertyAccessMode(PropertyAccessMode.Field); //  Доступ к _tags

            //  Индексы для быстрого поиска
            builder.HasIndex(p => p.Title);
            builder.HasIndex(p => p.CategoryId);
        }
    }

}
