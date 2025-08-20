using DayX.Database.Stock;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DayX.Infrastructure.Configurations
{
    /// <summary>
    /// Конфигурация сущности VariantAttributeValue.
    /// Описывает связь варианта продукта с конкретным значением атрибута.
    /// </summary>
    public class VariantAttributeValueConfiguration : IEntityTypeConfiguration<VariantAttributeValue>
    {
        public void Configure(EntityTypeBuilder<VariantAttributeValue> builder)
        {
            // Название таблицы в базе данных
            builder.ToTable("variant_attribute_values");


            // Первичный ключ — уникальный идентификатор значения
            builder.HasKey(x => x.Id);

            // Значение атрибута — обязательное, ограничено по длине
            builder.Property(x => x.Value)
                .IsRequired()
                .HasMaxLength(256);

            // Связь с вариантом продукта: один вариант может иметь много значений атрибутов
            builder.HasOne(x => x.ProductVariant)
                .WithMany(x => x.AttributeValues)
                .HasForeignKey(x => x.ProductVariantId)
                .OnDelete(DeleteBehavior.Cascade);

            // Связь с определением атрибута категории: один атрибут может использоваться в разных вариантах
            builder.HasOne(x => x.CategoryAttribute)
                .WithMany()
                .HasForeignKey(x => x.CategoryAttributeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Индекс для ускорения поиска по варианту и атрибуту
            builder.HasIndex(x => new { x.ProductVariantId, x.CategoryAttributeId });
        }
    }

}
