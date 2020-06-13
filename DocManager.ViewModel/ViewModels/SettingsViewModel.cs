using DocManager.Core;
using DocManager.ViewModel.Common;

namespace DocManager.ViewModel
{
    public class SettingsViewModel : PropertyChangedBase
    {
        private Settings settings;

        public string TemplatesPath
        {
            get => settings.TemplatesPath;
            set
            {
                settings.TemplatesPath = value;
                NotifyPropertyChanged(TemplatesPath);
            }
        }

        public string RootPath
        {
            get => settings.RootPath;
            set
            {
                settings.RootPath = value;
                NotifyPropertyChanged(RootPath);
            }
        }

        public SettingsViewModel()
        {
            settings = new Settings();
        }
    }
}
