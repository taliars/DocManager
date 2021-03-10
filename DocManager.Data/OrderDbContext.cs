using DocManager.Domain.Core.OrderEntities;
using DocManager.Domain.Core.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace DocManager.Infrastructure.Data
{
    public class OrderDbContext : DbContext
    {
        public DbSet<DbOrder> Orders { get; set; }

        public DbSet<DbCustomer> Customers { get; set; }

        public DbSet<DbDocument> Documents { get; set; }

        public DbSet<DbObjectData> ObjectDatas { get; set; }

        public DbSet<DbPerfomerRole> DbPerfomerRoles { get; set; }

        public DbSet<DbSubscription> Subscriptions { get; set; }

        public DbSet<DbPerfomer> Users { get; set; }

        public DbSet<DbVerificationInfo> VerificationInfos { get; set; }

        public DbSet<DbWeatherDay> WeatherDays { get; set; }

        public OrderDbContext(DbContextOptions<OrderDbContext> options)
             : base(options) { }

    }
}
