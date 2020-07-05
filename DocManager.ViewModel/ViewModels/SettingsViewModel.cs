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

        public string SourceFolderPath
        {
            get => settings.SourceFolderPath;
            set
            {
                settings.SourceFolderPath = value;
                NotifyPropertyChanged(SourceFolderPath);
            }
        }

        public SettingsViewModel()
        {
            settings = new Settings();
        }
    }
}
