using System.Collections.Generic;
using System.Collections.ObjectModel;
using DocManager.Abstractions;
using DocManager.Core;
using DocManager.ViewModel.Common;

namespace DocManager.ViewModel.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        private Act selectedAct;
        private Protocol selectedProtocol;
        private WeatherDay selectedWeatherDay;
        private Device selectedDevice;
        private Settings settings;

        private Order currentOrder;

        private readonly IActionHelper actionHelper;

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

        public ObservableCollection<Act> Acts { get; set; }

        public ObservableCollection<Protocol> Protocols { get; set; }

        public Act SelectedAct
        {
            get => selectedAct;
            set
            {
                selectedAct = value;
                NotifyPropertyChanged(nameof(SelectedAct));
            }
        }

        public Protocol SelectedProtocol
        {
            get => selectedProtocol;
            set
            {
                selectedProtocol = value;
                NotifyPropertyChanged(nameof(SelectedProtocol));
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

        public ObservableCollection<WeatherDay> WeatherDays { get; set; }

        public RelayCommand AddDate => new RelayCommand(o =>
        {
            WeatherDays.Add(new WeatherDay());
            NotifyPropertyChanged(nameof(WeatherDays));
        });

        public RelayCommand RemoveDate => new RelayCommand(o =>
        {
            WeatherDays.Remove(SelectedWeatherDay);
            NotifyPropertyChanged(nameof(WeatherDays));
        });

        public RelayCommand Open => new RelayCommand(async o => await actionHelper.OpenWithDefaultAppAsync((Document)o));

        public RelayCommand Move => new RelayCommand(async o => await actionHelper.MoveDocumentAsync(SelectedProtocol, Protocols, nameof(Protocols)));

        public RelayCommand Choose => new RelayCommand(async o =>
        {
            await actionHelper.UpdatePropertiesFolder((string) o);
        });

        public SettingsViewModel SettingsViewModel { get; set; }

        public RelayCommand SaveOrder => new RelayCommand(async o =>
        {
            var order = new Order
            {
                Id = currentOrder.Id,
                ObjectData = ObjectData,
                Acts = Acts,
                Protocols = Protocols,
                Devices = Devices,
                WeatherDays = WeatherDays,
            };

            await actionHelper.SaveOrderAsync(currentOrder.Id, order);
        });

        public RelayCommand AddOrder => new RelayCommand(async o =>
        {
            currentOrder = await actionHelper.CreateNewOrderAsync();
            OrderNames = actionHelper.GetGetOrderNames();
            NotifyPropertyChanged(nameof(OrderNames));
        });

        public RelayCommand GetOrder => new RelayCommand(o => { currentOrder = actionHelper.GetById(((OrderTuple)o)?.Id ?? currentOrder.Id); });

        public RelayCommand AddAct => new RelayCommand(o => { actionHelper.AddDocument(o, Acts, nameof(Acts)); });

        public RelayCommand RemoveAct => new RelayCommand(o => { actionHelper.RemoveDocument(o, Acts, nameof(Acts)); });

        public RelayCommand AddProtocol => new RelayCommand(o => { actionHelper.AddDocument(o, Protocols, nameof(Protocols)); });

        public RelayCommand RemoveProtocol => new RelayCommand(o => { actionHelper.RemoveDocument(o, Protocols, nameof(Protocols)); });

        public MainViewModel(IDialogCoordinator dialogCoordinator)
        {
            Settings = new Settings
            {
                TemplatesPath = Properties.DocManager.Default.TemplatesPath,
                SourceFolderPath = Properties.DocManager.Default.SourcePath,
            };

            actionHelper = new ActionHelper(dialogCoordinator, Settings);

            currentOrder = actionHelper.GetById(1);

            OrderNames = actionHelper.GetGetOrderNames();
            PassOrderData(this, currentOrder);

            StatusMessage = "Ready";
        }


        internal void UpdateAll()
        {
            string[] names =
            {
                nameof(OrderNames),
                nameof(ObjectData),
                nameof(Acts),
                nameof(Protocols),
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
            mainViewModel.Acts = new ObservableCollection<Act>(order?.Acts ?? new List<Act>());
            mainViewModel.Protocols = new ObservableCollection<Protocol>(order?.Protocols ?? new List<Protocol>());
            mainViewModel.Devices = new ObservableCollection<Device>(order?.Devices ?? new List<Device>());
            mainViewModel.WeatherDays = new ObservableCollection<WeatherDay>(order?.WeatherDays ?? new List<WeatherDay>());
            mainViewModel.UpdateAll();
        }
    }
}