using DocManager.Core;
using DocManager.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DocManager.ViewModel
{
    public class MainViewModel : PropertyChangedBase
    {
        private Act selectedAct;
        private Protocol selectedProtocol;
        private WeatherDay selectedWeatherDay;
        private Device selectedDevice;

        private Order currentOrder;

        private readonly ActionsHelper actionHelper;

        public string StatusMessage { get; set; }

        public List<OrderTuple> OrderNames { get; set; }

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

        public RelayCommand OpenAct => new RelayCommand(async o => await actionHelper.OpenWithDefaultAppAsync(SelectedAct));

        public RelayCommand Move => new RelayCommand(async o => await actionHelper.MoveDocumentAsync(SelectedProtocol, Protocols, nameof(Protocols)));

        public SettingsViewModel SettingsViewModel { get; set; }

        public RelayCommand SaveOrder => new RelayCommand(async o => await actionHelper.SaveOrderAsync(currentOrder.Id, this));

        public RelayCommand AddOrder => new RelayCommand(async o =>
        {
            currentOrder = await actionHelper.CreateNewOrderAsync();
            OrderNames = actionHelper.GetGetOrderNames();
            NotifyPropertyChanged(nameof(OrderNames));
        });

        public RelayCommand GetOrder => new RelayCommand(o => { currentOrder = actionHelper.GetById(((OrderTuple)o)?.Id ?? currentOrder.Id , this); });

        public RelayCommand AddAct => new RelayCommand(o => { actionHelper.AddDocument(o, Acts, nameof(Acts)); });

        public RelayCommand RemoveAct => new RelayCommand(o => { actionHelper.RemoveDocument(o, Acts, nameof(Acts)); });

        public RelayCommand AddProtocol => new RelayCommand(o => { actionHelper.AddDocument(o, Protocols, nameof(Protocols)); });

        public RelayCommand RemoveProtocol => new RelayCommand(o => { actionHelper.RemoveDocument(o, Protocols, nameof(Protocols)); });

        public MainViewModel(
            Func<string, string, bool, Task<bool>> actionAffirm,
            Func<string, string, Task<string>> inputAffirm,
            Func<string, string, string> moveAffirm)
        {
            var settings = new Settings
            {
                TemplatesPath = @"D:\trash\DocManager\норд\формы протоколов",
                SourceFolderPath = @"D:\trash\DocManager\норд\source",
                FinalPath = @"D:\trash\DocManager\норд\final",
            };

            actionHelper = new ActionsHelper(moveAffirm, actionAffirm, inputAffirm, settings);

            currentOrder = actionHelper.GetById(1, this);

            OrderNames = actionHelper.GetGetOrderNames();
            actionHelper.PassOrderData(this, currentOrder);

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

    }
}