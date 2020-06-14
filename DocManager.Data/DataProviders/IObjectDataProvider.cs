using DocManager.Core;

namespace DocManager.Data.DataProviders
{
    public interface IOrderDataProvider
    {
        OrderData OrderData { get; }

        void Save();
    }
}
