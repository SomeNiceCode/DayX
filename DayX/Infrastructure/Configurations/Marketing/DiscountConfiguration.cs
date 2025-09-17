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
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(d => d.Id);

            /// <summary>
            /// Настройка поля Title — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(d => d.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            /// <summary>
            /// Настройка поля Percentage — обязательное, decimal(5,2).
            /// </summary>
            builder.Property(d => d.Percentage)
                   .IsRequired()
                   .HasColumnType("decimal(5,2)");

            /// <summary>
            /// Настройка поля StartDate — обязательное.
            /// </summary>
            builder.Property(d => d.StartDate)
                   .IsRequired();

            /// <summary>
            /// Настройка поля EndDate — обязательное.
            /// </summary>
            builder.Property(d => d.EndDate)
                   .IsRequired();

            /// <summary>
            /// Настройка поля SellerId — обязательное.
            /// </summary>
            builder.Property(d => d.SellerId)
                   .IsRequired();

            /// <summary>
            /// Связь с продавцом (многие скидки — один продавец).
            /// </summary>
            builder.HasOne(d => d.Seller)
                   .WithMany(s => s.Discounts)
                   .HasForeignKey(d => d.SellerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

