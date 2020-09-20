using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DocManager.Core;

namespace DocManager.Abstractions
{
    public interface IDocumentHelper
    {
        void RemoveDocument<T>(object o, ObservableCollection<T> collection, string name) where T : Document, new();

        void AddDocument<T>(object o, ObservableCollection<T> collection, string name) where T : Document, new();

        Task MoveDocumentAsync<T>(T document, ObservableCollection<T> documents, string name) where T : Document;

        Task OpenWithDefaultAppAsync<T>(T document) where T : Document;
    }
}
