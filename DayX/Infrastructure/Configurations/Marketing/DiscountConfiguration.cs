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
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            // Первичный ключ
            builder.HasKey(d => d.Id);

            // Title — обязательное, макс. длина 200
            builder.Property(d => d.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            // Percentage — обязательное, decimal(5,2)
            builder.Property(d => d.Percentage)
                   .IsRequired()
                   .HasColumnType("decimal(5,2)");

            // StartDate — обязательное
            builder.Property(d => d.StartDate)
                   .IsRequired();

            // EndDate — обязательное
            builder.Property(d => d.EndDate)
                   .IsRequired();

            // SellerId — обязательное
            builder.Property(d => d.SellerId)
                   .IsRequired();

            // Связь с продавцом (многие скидки — один продавец)
            builder.HasOne(d => d.Seller)
                   .WithMany(s => s.Discounts)
                   .HasForeignKey(d => d.SellerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

