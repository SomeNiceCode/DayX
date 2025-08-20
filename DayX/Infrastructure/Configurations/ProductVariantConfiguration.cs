using DayX.Database.Catalog;
using DayX.Database.Stock;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DayX.Infrastructure.Configurations
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            //  Первичный ключ
            builder.HasKey(v => v.Id);

            //  Название варианта
            builder.Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(150);

            //  Цена
            builder.Property(v => v.Price)
                .IsRequired()
                .HasPrecision(18, 2);

            //  Остаток
            builder.Property(v => v.StockQuantity)
                .IsRequired();

            //  Связь с Product (без навигации в Product)
            builder.HasOne<Product>()
                .WithMany() //  без навигации
                .HasForeignKey(v => v.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            //  Атрибуты варианта
            builder.HasMany<VariantAttributeValue>()
                .WithOne()
                .HasForeignKey("VariantId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Metadata
                .FindNavigation(nameof(ProductVariant.AttributeValues))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            //  Индексы
            builder.HasIndex(v => v.ProductId);
            builder.HasIndex(v => v.Price);
            builder.HasIndex(v => v.StockQuantity);
        }
    }


}
