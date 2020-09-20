using System.Collections.Generic;
using DocManager.Abstractions;
using DocManager.Core;
using DocManager.Helpers;
using DocManager.ViewModel.Common;

namespace DocManager.ViewModel.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        private Settings settings;

        public string StatusMessage { get; set; }

        public Settings Settings
        {
            get => settings;
            set
            {
                settings = value;
                NotifyPropertyChanged(nameof(Settings));
            }
        }

        public ObjectData ObjectData { get; set; }

        public SettingsViewModel SettingsViewModel { get; set; }

        public DocumentViewModel DocumentViewModel { get; set; }

        public OrderViewModel OrderViewModel { get; set; }

        public WeatherDaysViewModel WeatherDaysViewModel { get; set; }

        public DevicesViewModel DevicesViewModel { get; set; }

        public RelayCommand Choose { get; }

        public MainViewModel(IDialogCoordinator dialogCoordinator)
        {
            Settings = new Settings
            {
                TemplatesPath = Properties.DocManager.Default.TemplatesPath,
                SourceFolderPath = Properties.DocManager.Default.SourcePath,
            };

            IOrderHelper orderHelper = new OrderHelper();

            var currentOrder = orderHelper.GetById(1);

            StatusMessage = "Ready";
        }
    }
}