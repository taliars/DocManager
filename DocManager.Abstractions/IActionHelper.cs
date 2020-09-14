using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DocManager.Core;

namespace DocManager.Abstractions
{
    public interface IActionHelper
    {
        void RemoveDocument<T>(object o, ObservableCollection<T> collection, string name) where T : Document, new();

        void AddDocument<T>(object o, ObservableCollection<T> collection, string name) where T : Document, new();

        Task MoveDocumentAsync<T>(T document, ObservableCollection<T> documents, string name) where T : Document;

        Task UpdatePropertiesFolder(string name);

        Task OpenWithDefaultAppAsync<T>(T document) where T : Document;

        Task SaveOrderAsync(int orderId, Order order);

        Task<Order> CreateNewOrderAsync();

        Order GetById(int orderId);

        List<OrderTuple> GetGetOrderNames();
    }
}
