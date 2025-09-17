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
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            // Первичный ключ
            builder.HasKey(s => s.Id);

            // UserId — опциональное
            builder.Property(s => s.UserId)
                   .IsRequired(false);

            // Name — обязательное, макс. длина 200
            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            // CreatedAt — обязательное
            builder.Property(s => s.CreatedAt)
                   .IsRequired();

            // Связь с пользователем (один пользователь может быть продавцом)
            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(s => s.UserId)
                   .OnDelete(DeleteBehavior.SetNull);

            // Связь с товарами (один продавец — много товаров)
            builder.HasMany(s => s.Products)
                   .WithOne()
                   .HasForeignKey("SellerId")
                   .OnDelete(DeleteBehavior.Cascade);

            // ❌ Блок со скидками убран — связь настраивается в DiscountConfiguration
        }
    }
}


