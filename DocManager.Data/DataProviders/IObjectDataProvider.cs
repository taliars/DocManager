using DocManager.Core;

namespace DocManager.Data.DataProviders
{
    public interface IObjectDataProvider
    {
        ObjectData ObjectData { get; }

        void Save(ObjectData objectData);
    }
}
