using Discount.GRPC.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.GRPC.Data
{
    public class DiscountContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; } = default!;
        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon {Id=Guid.NewGuid(),ProductName="Iphone 17",Description="Iphonediscount",Amount=2000 }

                );
        }
    }
}
