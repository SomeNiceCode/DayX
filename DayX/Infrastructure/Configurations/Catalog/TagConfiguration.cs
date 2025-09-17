using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Catalog;

namespace DayX.Infrastructure.Configurations.Catalog
{
    /// <summary>
    /// Конфигурация сущности <see cref="Tag"/> для EF Core.
    /// Определяет ключи, ограничения и связи для таблицы тегов.
    /// </summary>
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        /// <summary>
        /// Настраивает модель <see cref="Tag"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="Tag"/>.</param>
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(t => t.Id);

            /// <summary>
            /// Настройка поля Name — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            /// <summary>
            /// Связь с ProductTag (один тег — много связей с продуктами).
            /// </summary>
            builder.HasMany(t => t.ProductTags)
                   .WithOne()
                   .HasForeignKey(pt => pt.TagId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
