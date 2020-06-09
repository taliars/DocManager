using DocManager.Core;

namespace DocManager.ViewModel
{
    public interface IObjectDataProvider
    {
        InnerObjectDataViewModel GetObjectData { get; }
    }
}