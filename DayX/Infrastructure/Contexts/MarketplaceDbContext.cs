using Microsoft.EntityFrameworkCore;

// Подключаем все пространства имён с сущностями
using DayX.Database.Users;
using DayX.Database.Sellers;
using DayX.Database.Catalog;
using DayX.Database.Marketing;
using DayX.Database.Carts;
using DayX.Database.Orders;
using DayX.Database.PayDelivery;
using DayX.Database.Reviews;
using DayX.Database.Stock;
using DayX.Database.Admin;

namespace DayX.Infrastructure.Contexts
{
    public class MarketplaceDbContext : DbContext
    {
        public MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options) : base(options) { }

        // Users
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }

        // Sellers
        public DbSet<Seller> Sellers { get; set; }

        // Catalog
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryAttribute> CategoryAttributes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Tag> Tags { get; set; }

        // Marketing
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }

        // Carts
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        // Orders
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        // OrderStatus — enum, хранится в Order.Status

        // PayDelivery
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Shipment> Shipments { get; set; }

        // Reviews
        public DbSet<Review> Reviews { get; set; }

        // Stock
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<StockEntry> StockEntries { get; set; }
        public DbSet<VariantAttributeValue> VariantAttributeValues { get; set; }

        // Admin
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Автоматически применяем все конфигурации из Infrastructure/Configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MarketplaceDbContext).Assembly);
        }
    }
}
