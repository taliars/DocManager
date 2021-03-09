using DocManager.Domain.Core.OrderEntities;
using Microsoft.EntityFrameworkCore;

namespace DocManager.Infrastructure.Data
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrderDbContext(DbContextOptions<OrderDbContext> options)
             : base(options){ }
    }
}
