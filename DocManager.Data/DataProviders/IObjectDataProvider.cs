using DocManager.Core;
using System.Collections.Generic;

namespace DocManager.Data.DataProviders
{
    public interface IOrderDataProvider
    {
        OrderData OrderData { get; }

        void Save();
    }
}
