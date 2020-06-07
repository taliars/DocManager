using DocManager.Core;

namespace DocManager.ViewModel
{
    public interface IObjectInfoProvider
    {
        ObjectInfo GetObjectInfo { get; }
    }
}