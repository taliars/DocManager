using DocManager.Data.DataProviders;

namespace DocManager.ViewModel
{
    public class ObjectDataProvider
    {
        public static ObjectDataViewModel GetObjectData => new ObjectDataViewModel(new JsonDataProvider("abc"));
    }
}

