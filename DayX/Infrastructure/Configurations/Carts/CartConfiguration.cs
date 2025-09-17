using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayX.Database.Carts;
using DayX.Database.Users;

namespace DayX.Infrastructure.Configurations.Carts
{
    /// <summary>
    /// Конфигурация сущности <see cref="Cart"/> для EF Core.
    /// Определяет ключи, ограничения и связи для таблицы корзин пользователей.
    /// </summary>
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        /// <summary>
        /// Настраивает модель <see cref="Cart"/> с помощью Fluent API.
        /// </summary>
        /// <param name="builder">Построитель конфигурации для сущности <see cref="Cart"/>.</param>
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            /// <summary>
            /// Устанавливаем первичный ключ.
            /// </summary>
            builder.HasKey(c => c.Id);

            /// <summary>
            /// Настройка поля UserId — обязательное.
            /// </summary>
            builder.Property(c => c.UserId)
                   .IsRequired();

            /// <summary>
            /// Связь с пользователем (один пользователь — одна корзина).
            /// </summary>
            builder.HasOne<User>()
                   .WithOne()
                   .HasForeignKey<Cart>(c => c.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            /// <summary>
            /// Связь с элементами корзины (одна корзина — много элементов).
            /// </summary>
            builder.HasMany(c => c.Items)
                   .WithOne()
                   .HasForeignKey("CartId") // FK в CartItem
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

