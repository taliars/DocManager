using DocManager.Core;
using System.Collections.Generic;

namespace DocManager.Data
{
    public interface IOrderData
    {
        Order GetById(int id);

        Order Update(Order order);

        Order Add(Order order);

        Order Delete(int id);

        IEnumerable<int> GetOrderIds { get; }

        int Commit();
    }
}
