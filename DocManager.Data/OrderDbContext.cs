using DocManager.Core.OrderEntities;
using DocManager.Core.AuthEntities;
using Microsoft.EntityFrameworkCore;

namespace DocManager.Infrastructure.Data
{
    public class OrderDbContext : DbContext
    {
        public DbSet<DbOrder> Orders { get; set; }

        public DbSet<DbCustomer> Customers { get; set; }

        public DbSet<DbDocument> Documents { get; set; }

        public DbSet<DbObjectData> ObjectDatas { get; set; }

        public DbSet<DbPosition> DbPerfomerRoles { get; set; }

        public DbSet<DbVerificationInfo> VerificationInfos { get; set; }

        public DbSet<DbWeatherDay> WeatherDays { get; set; }

        public DbSet<DbLogin> Logins { get; set; }

        public DbSet<DbPerson> Persons { get; set; }

        public DbSet<DbPosition> Positions { get; set; }

        public DbSet<DbSubscription> Subscriptions { get; set; }

        public OrderDbContext(DbContextOptions<OrderDbContext> options)
             : base(options) { }
    }
}
