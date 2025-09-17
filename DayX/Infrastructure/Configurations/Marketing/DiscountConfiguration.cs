using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Marketing;
using DayX.Database.Sellers;

namespace DayX.Infrastructure.Configurations.Marketing
{
    /// <summary>
    /// Конфигурация сущности <see cref="Discount"/> для EF Core.
    /// Определяет ключи, ограничения и связи для таблицы скидок.
    /// </summary>
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        /// <summary>
        /// Настраивает модель <see cref="Discount"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="Discount"/>.</param>
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            // Первичный ключ
            builder.HasKey(d => d.Id);

            // Заголовок — обязательный, макс. длина 200
            builder.Property(d => d.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            // Процент — обязательный, decimal(5,2)
            builder.Property(d => d.Percentage)
                   .IsRequired()
                   .HasColumnType("decimal(5,2)");

            // Даты — обязательные
            builder.Property(d => d.StartDate)
                   .IsRequired();

            builder.Property(d => d.EndDate)
                   .IsRequired();

            // FK к продавцу — обязательный
            builder.Property(d => d.SellerId)
                   .IsRequired();

            // Связь с продавцом (многие скидки — один продавец)
            builder.HasOne(d => d.Seller)
                   .WithMany(s => s.Discounts)
                   .HasForeignKey(d => d.SellerId) // Явно указываем FK
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

