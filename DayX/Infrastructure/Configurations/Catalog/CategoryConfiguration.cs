using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Catalog;

namespace DayX.Infrastructure.Configurations.Catalog
{
    /// <summary>
    /// Конфигурация сущности <see cref="Category"/> для EF Core.
    /// Определяет ключи, ограничения и связи для таблицы категорий товаров.
    /// </summary>
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        /// <summary>
        /// Настраивает модель <see cref="Category"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="Category"/>.</param>
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(c => c.Id);

            /// <summary>
            /// Настройка поля Name — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            /// <summary>
            /// Связь с атрибутами категории (одна категория — много атрибутов).
            /// </summary>
            builder.HasMany(c => c.Attributes)
                   .WithOne()
                   .HasForeignKey("CategoryId")
                   .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Связь с продуктами (одна категория — много продуктов).
            /// </summary>
            builder.HasMany(c => c.Products)
                   .WithOne()
                   .HasForeignKey("CategoryId")
                   .OnDelete(DeleteBehavior.Restrict);

            /// <summary>
            /// Связь с тегами (одна категория — много тегов).
            /// </summary>
            builder.HasMany(c => c.Tags)
                   .WithOne()
                   .HasForeignKey("CategoryId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

