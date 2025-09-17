using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Sellers;
using DayX.Database.Users;

namespace DayX.Infrastructure.Configurations.Sellers
{
    /// <summary>
    /// Конфигурация сущности <see cref="Seller"/> для EF Core.
    /// Определяет ключи, ограничения и связи для таблицы продавцов.
    /// </summary>
    public class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        /// <summary>
        /// Настраивает модель <see cref="Seller"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="Seller"/>.</param>
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(s => s.Id);

            /// <summary>
            /// Настройка поля UserId — опциональное.
            /// </summary>
            builder.Property(s => s.UserId)
                   .IsRequired(false);

            /// <summary>
            /// Настройка поля Name — обязательное, с ограничением длины.
            /// </summary>
            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            /// <summary>
            /// Настройка поля CreatedAt — обязательное.
            /// </summary>
            builder.Property(s => s.CreatedAt)
                   .IsRequired();

            /// <summary>
            /// Связь с пользователем (один пользователь может быть продавцом).
            /// </summary>
            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(s => s.UserId)
                   .OnDelete(DeleteBehavior.SetNull);

            /// <summary>
            /// Связь с товарами (один продавец — много товаров).
            /// </summary>
            builder.HasMany(s => s.Products)
                   .WithOne()
                   .HasForeignKey("SellerId")
                   .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Связь со скидками (один продавец — много скидок).
            /// </summary>
            builder.HasMany(s => s.Discounts)
                   .WithOne()
                   .HasForeignKey("SellerId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

