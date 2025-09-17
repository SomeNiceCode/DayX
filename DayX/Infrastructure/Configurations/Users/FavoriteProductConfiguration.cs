using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Users;
using DayX.Database.Stock;

namespace DayX.Infrastructure.Configurations.Users
{
    /// <summary>
    /// Конфигурация сущности <see cref="FavoriteProduct"/> для EF Core.
    /// Определяет ключи, ограничения и связи для таблицы избранных товаров пользователей.
    /// </summary>
    public class FavoriteProductConfiguration : IEntityTypeConfiguration<FavoriteProduct>
    {
        /// <summary>
        /// Настраивает модель <see cref="FavoriteProduct"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="FavoriteProduct"/>.</param>
        public void Configure(EntityTypeBuilder<FavoriteProduct> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(fp => fp.Id);

            /// <summary>
            /// Настройка поля UserId — обязательное.
            /// </summary>
            builder.Property(fp => fp.UserId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля ProductVariantId — обязательное.
            /// </summary>
            builder.Property(fp => fp.ProductVariantId)
                   .IsRequired();

            /// <summary>
            /// Настройка поля AddedAt — обязательное.
            /// </summary>
            builder.Property(fp => fp.AddedAt)
                   .IsRequired();

            /// <summary>
            /// Связь с пользователем (многие избранные товары — один пользователь).
            /// </summary>
            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(fp => fp.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Связь с вариантом продукта (многие избранные товары — один вариант).
            /// </summary>
            builder.HasOne<ProductVariant>()
                   .WithMany()
                   .HasForeignKey(fp => fp.ProductVariantId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

