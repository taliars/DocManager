using DocManager.Domain.Core.OrderEntities;
using DocManager.Domain.Core.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace DocManager.Infrastructure.Data
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<ObjectData> ObjectDatas { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<VerificationInfo> VerificationInfos { get; set; }

        public DbSet<WeatherDay> WeatherDays { get; set; }

        public OrderDbContext(DbContextOptions<OrderDbContext> options)
             : base(options) { }

    }
}
