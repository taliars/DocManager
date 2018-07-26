using System.Collections.ObjectModel;

namespace MRL.ViewModel
{
    public class MainViewModel
    {
        private readonly ObjectDataProvider ObjectDataProvider = new ObjectDataProvider();
        public ObjectDataViewModel ObjectData { get; set; }

        public MainViewModel()
        {
            ObjectData = ObjectDataProvider.GetObjectData();
        }
    }
}
