using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DocManager.Core;

namespace DocManager.Abstractions
{
    public interface IDocumentActionHelper
    {
        void Remove<T>(object o, ObservableCollection<T> collection, string name) where T : Document, new();

        void Add<T>(object o, ObservableCollection<T> collection, string name) where T : Document, new();

        Task MoveAsync<T>(T document, ObservableCollection<T> documents, string name) where T : Document;

        Task OpenWithDefaultAppAsync<T>(T document) where T : Document;
    }
}
