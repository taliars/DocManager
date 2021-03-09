using DocManager.Domain.Core.OrderEntities;
using DocManager.Infrastructure.Data;
using DocManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DocManager.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly OrderDbContext orderDbContext;


        public OrderService(OrderDbContext orderDbContext)
        {
            this.orderDbContext = orderDbContext;
        }

        public DbOrder Create()
        {
            throw new System.NotImplementedException();
        }

        public void Delele(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<DbOrder> GetByIdAsync(int id)
        {
            return await orderDbContext.Set<DbOrder>()
                .Include(x => x.Subscription)
                .Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public DbOrder Update(DbOrder dbOrder)
        {
            throw new System.NotImplementedException();
        }
    }
}
