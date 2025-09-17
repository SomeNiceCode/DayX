using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Reviews;
using DayX.Database.Catalog;
using DayX.Database.Users;

namespace DayX.Infrastructure.Configurations.Reviews
{
    /// <summary>
    /// Конфигурация сущности <see cref="Review"/> для EF Core.
    /// Определяет ключи, ограничения и связи для таблицы отзывов.
    /// </summary>
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        /// <summary>
        /// Настраивает модель <see cref="Review"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="Review"/>.</param>
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(r => r.Id);

            /// <summary>
            /// Настройка поля ProductId — обязательное.
            /// </summary>
            builder.Property(r => r.ProductId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля UserId — обязательное.
            /// </summary>
            builder.Property(r => r.UserId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля Comment — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(r => r.Comment)
                   .IsRequired()
                   .HasMaxLength(2000);

            /// <summary>
            /// Настройка поля Rating — обязательное.
            /// </summary>
            builder.Property(r => r.Rating)
                   .IsRequired();

            /// <summary>
            /// Настройка поля CreatedAt — обязательное.
            /// </summary>
            builder.Property(r => r.CreatedAt)
                   .IsRequired();

            /// <summary>
            /// Связь с продуктом (многие отзывы — один продукт).
            /// </summary>
            builder.HasOne<Product>()
                   .WithMany()
                   .HasForeignKey(r => r.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Связь с пользователем (многие отзывы — один пользователь).
            /// </summary>
            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
