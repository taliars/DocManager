using System.Collections.Generic;
using System.Collections.ObjectModel;
using DocManager.Abstractions;
using DocManager.Core;
using DocManager.ViewModel.Common;

namespace DocManager.ViewModel.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        private Document selectedDocument;
        private WeatherDay selectedWeatherDay;
        private Device selectedDevice;
        private Settings settings;

        public string StatusMessage { get; set; }

        public List<OrderTuple> OrderNames { get; set; }

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

        public ObservableCollection<Device> Devices { get; set; }

        public ObservableCollection<Document> Documents { get; set; }

        public ObservableCollection<WeatherDay> WeatherDays { get; set; }

        public Document SelectedDocument
        {
            get => selectedDocument;
            set
            {
                selectedDocument = value;
                NotifyPropertyChanged(nameof(SelectedDocument));
            }
        }

        public WeatherDay SelectedWeatherDay
        {
            get => selectedWeatherDay;
            set
            {
                selectedWeatherDay = value;
                NotifyPropertyChanged(nameof(SelectedWeatherDay));
            }
        }

        public Device SelectedDevice
        {
            get => selectedDevice;
            set
            {
                selectedDevice = value;
                NotifyPropertyChanged(nameof(SelectedDevice));
            }
        }

        public RelayCommand AddDate { get; }

        public RelayCommand RemoveDate { get; }

        public SettingsViewModel SettingsViewModel { get; set; }

        public RelayCommand SaveOrder { get; }

        public RelayCommand AddOrder { get; }

        public RelayCommand GetOrder { get; }

        public RelayCommand AddDocument { get; }

        public RelayCommand RemoveDocument { get; }
        
        public RelayCommand Open { get; }

        public RelayCommand Move { get; }

        public RelayCommand Choose { get; }

        public MainViewModel(IDialogCoordinator dialogCoordinator)
        {
            Settings = new Settings
            {
                TemplatesPath = Properties.DocManager.Default.TemplatesPath,
                SourceFolderPath = Properties.DocManager.Default.SourcePath,
            };

            IActionHelper actionHelper = new ActionHelper(dialogCoordinator, Settings);

            var currentOrder = actionHelper.GetById(1);

            OrderNames = actionHelper.GetGetOrderNames();
            PassOrderData(this, currentOrder);

            GetOrder = new RelayCommand(o => { currentOrder = actionHelper.GetById(((OrderTuple)o)?.Id ?? currentOrder.Id); });
            AddDocument = new RelayCommand(o => { actionHelper.AddDocument(o, Documents, nameof(Documents)); });
            RemoveDocument = new RelayCommand(o => { actionHelper.RemoveDocument(o, Documents, nameof(Documents)); });
            Open = new RelayCommand(async o => await actionHelper.OpenWithDefaultAppAsync((Document)o));
            Move = new RelayCommand(async o => await actionHelper.MoveDocumentAsync(SelectedDocument, Documents, nameof(Documents)));
            Choose = new RelayCommand(async o => await actionHelper.UpdatePropertiesFolder((string)o));
            SaveOrder = new RelayCommand(async o =>
            {
                var order = new Order
                {
                    Id = currentOrder.Id,
                    ObjectData = ObjectData,
                    Documents = Documents,
                    Devices = Devices,
                    WeatherDays = WeatherDays,
                };

                await actionHelper.SaveOrderAsync(currentOrder.Id, order);
            });

            AddOrder = new RelayCommand(async o =>
            {
                currentOrder = await actionHelper.CreateNewOrderAsync();
                OrderNames = actionHelper.GetGetOrderNames();
                NotifyPropertyChanged(nameof(OrderNames));
            });

            AddDate = new RelayCommand(o =>
            {
                WeatherDays.Add(new WeatherDay());
                NotifyPropertyChanged(nameof(WeatherDays));
            });

            RemoveDate = new RelayCommand(o =>
            {
                WeatherDays.Remove(SelectedWeatherDay);
                NotifyPropertyChanged(nameof(WeatherDays));
            });

            StatusMessage = "Ready";
        }


        internal void UpdateAll()
        {
            string[] names =
            {
                nameof(OrderNames),
                nameof(ObjectData),
                nameof(Documents),
                nameof(Devices),
                nameof(WeatherDays)
            };

            foreach (var name in names)
            {
                NotifyPropertyChanged(name);
            }
        }

        public void PassOrderData(MainViewModel mainViewModel, Order order)
        {
            mainViewModel.ObjectData = order?.ObjectData ?? new ObjectData();
            mainViewModel.Documents = new ObservableCollection<Document>(order?.Documents ?? new List<Document>());
            mainViewModel.Devices = new ObservableCollection<Device>(order?.Devices ?? new List<Device>());
            mainViewModel.WeatherDays = new ObservableCollection<WeatherDay>(order?.WeatherDays ?? new List<WeatherDay>());
            mainViewModel.UpdateAll();
        }
    }
}