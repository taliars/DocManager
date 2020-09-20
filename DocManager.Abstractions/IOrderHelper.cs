using System.Collections.Generic;
using System.Threading.Tasks;
using DocManager.Core;

namespace DocManager.Abstractions
{
    public interface IOrderHelper
    {
        Task SaveOrderAsync(int orderId, Order order);

        Task<Order> CreateNewOrderAsync();

        Order GetById(int orderId);

        List<OrderTuple> GetOrderNames();
    }
}
