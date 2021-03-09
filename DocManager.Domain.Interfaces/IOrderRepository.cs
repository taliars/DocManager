using DocManager.Domain.Core.OrderEntities;
using System.Collections.Generic;

namespace DocManager.Domain.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrderList();

        Order GetById(int id);

        Order Update(Order order);

        Order Add(Order order);

        Order Delete(int id);

        void Save();
    }
}
