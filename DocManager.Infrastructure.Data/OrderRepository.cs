using DocManager.Domain.Core.OrderEntities;
using DocManager.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DocManager.Infrastructure.Data
{
    public class OrderRepository : IOrderRepository
    {
        private OrderDbContext orderDbContext;

        public OrderRepository(OrderDbContext orderDbContext)
        {
            this.orderDbContext = orderDbContext;
        }

        public Order Add(Order order)
        {
            orderDbContext.Orders.Add(order);
            return order;
        }

        public Order Delete(int id)
        {
            var order = orderDbContext.Orders.FirstOrDefault(x => x.Id == id);

            if (order != null)
            {
                orderDbContext.Orders.Remove(order);
            }

            return order;
        }

        public Order GetById(int id)
        {
            return orderDbContext.Orders.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Order> GetOrderList()
        {
            return orderDbContext.Orders.Include(x => x.Subscription);
        }

        public void Save()
        {
            orderDbContext.SaveChanges();
        }

        public Order Update(Order order)
        {
            orderDbContext.Entry(order).State = EntityState.Modified;
            return order;
        }
    }
}
