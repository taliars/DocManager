namespace DocManager.ViewModel
{
    public class MainViewModel
    {
        public ObjectDataViewModel ObjectData { get; set; }

        public MainViewModel()
        {
            ObjectData = ObjectDataProvider.GetObjectData();
        }
    }
}
