using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocManager.Abstractions;
using DocManager.Core;

namespace DocManager.Helpers
{
    public class OrderHelper : IOrderHelper
    {
        public OrderHelper()
        {

        }

        public Task SaveOrderAsync(int orderId, Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order> CreateNewOrderAsync()
        {
            throw new NotImplementedException();
        }

        public Order GetById(int orderId)
        {
            throw new NotImplementedException();
        }

        public List<OrderTuple> GetOrderNames()
        {
            throw new NotImplementedException();
        }
    }
}
