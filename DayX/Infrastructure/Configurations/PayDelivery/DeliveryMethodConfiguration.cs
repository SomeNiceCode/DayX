using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.PayDelivery;

namespace DayX.Infrastructure.Configurations.PayDelivery
{
    /// <summary>
    /// Конфигурация сущности <see cref="DeliveryMethod"/> для EF Core.
    /// Определяет ключи, ограничения и связи для таблицы методов доставки.
    /// </summary>
    public class DeliveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod>
    {
        /// <summary>
        /// Настраивает модель <see cref="DeliveryMethod"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="DeliveryMethod"/>.</param>
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(dm => dm.Id);

            /// <summary>
            /// Настройка поля Name — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(dm => dm.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            /// <summary>
            /// Настройка поля Price — обязательное, decimal(18,2).
            /// </summary>
            builder.Property(dm => dm.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            /// <summary>
            /// Настройка поля EstimatedTime — обязательное.
            /// </summary>
            builder.Property(dm => dm.EstimatedTime)
                   .IsRequired();
        }
    }
}
