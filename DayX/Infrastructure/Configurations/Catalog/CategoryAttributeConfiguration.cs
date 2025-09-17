using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Catalog;

namespace DayX.Infrastructure.Configurations.Catalog
{
    /// <summary>
    /// Конфигурация сущности <see cref="CategoryAttribute"/> для EF Core.
    /// Определяет ключи, ограничения и связи для таблицы атрибутов категорий.
    /// </summary>
    public class CategoryAttributeConfiguration : IEntityTypeConfiguration<CategoryAttribute>
    {
        /// <summary>
        /// Настраивает модель <see cref="CategoryAttribute"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="CategoryAttribute"/>.</param>
        public void Configure(EntityTypeBuilder<CategoryAttribute> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(ca => ca.Id);

            /// <summary>
            /// Настройка поля CategoryId — обязательное.
            /// </summary>
            builder.Property(ca => ca.CategoryId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля Name — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(ca => ca.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            /// <summary>
            /// Настройка поля DataType — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(ca => ca.DataType)
                   .IsRequired()
                   .HasMaxLength(50);

            /// <summary>
            /// Настройка поля IsRequired — обязательное.
            /// </summary>
            builder.Property(ca => ca.IsRequired)
                   .IsRequired();

            /// <summary>
            /// Настройка поля IsFilterable — обязательное.
            /// </summary>
            builder.Property(ca => ca.IsFilterable)
                   .IsRequired();

            /// <summary>
            /// Связь с категорией (многие к одному).
            /// </summary>
            builder.HasOne<Category>()
                   .WithMany(c => c.Attributes)
                   .HasForeignKey(ca => ca.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
