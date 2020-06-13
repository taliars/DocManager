using DocManager.ViewModel.Common;

namespace DocManager.ViewModel
{
    public class SettingsViewModel : PropertyChangedBase
    {
        private string templatesPath = @"C:/";

        private string rootPath = @"D:/";

        public string TemplatesPath
        {
            get => templatesPath;
            set
            {
                templatesPath = value;
                NotifyPropertyChanged(TemplatesPath);
            }
        }

        public string RootPath
        {
            get => rootPath;
            set
            {
                rootPath = value;
                NotifyPropertyChanged(RootPath);
            }
        }
    }
}
