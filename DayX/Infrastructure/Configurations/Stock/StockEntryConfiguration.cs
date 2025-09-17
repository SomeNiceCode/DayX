using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Stock;

namespace DayX.Infrastructure.Configurations.Stock
{
    /// <summary>
    /// Конфигурация сущности <see cref="StockEntry"/> для EF Core.
    /// Определяет ключи, ограничения и связи для таблицы записей об изменении складских остатков.
    /// </summary>
    public class StockEntryConfiguration : IEntityTypeConfiguration<StockEntry>
    {
        /// <summary>
        /// Настраивает модель <see cref="StockEntry"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="StockEntry"/>.</param>
        public void Configure(EntityTypeBuilder<StockEntry> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(se => se.Id);

            /// <summary>
            /// Настройка поля ProductVariantId — обязательное.
            /// </summary>
            builder.Property(se => se.ProductVariantId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля QuantityChange — обязательное.
            /// </summary>
            builder.Property(se => se.QuantityChange)
                   .IsRequired();

            /// <summary>
            /// Настройка поля Timestamp — обязательное.
            /// </summary>
            builder.Property(se => se.Timestamp)
                   .IsRequired();

            /// <summary>
            /// Настройка поля Reason — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(se => se.Reason)
                   .IsRequired()
                   .HasMaxLength(500);

            /// <summary>
            /// Связь с вариантом продукта (многие записи — один вариант).
            /// </summary>
            builder.HasOne<ProductVariant>()
                   .WithMany()
                   .HasForeignKey(se => se.ProductVariantId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

