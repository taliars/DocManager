using DocManager.Core;
using DocManager.Data;
using DocManager.Data.Json;
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

        private readonly IOrderData orderData;
        private Order currentOrder;

        private int orderId;
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

        public Device SelectedDevice { get; set; }

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

        public RelayCommand OpenAct => new RelayCommand(async o => await actionHelper.OpenWithDefaultApp(SelectedAct));

        public RelayCommand Move => new RelayCommand(async o => await actionHelper.MoveDocument(SelectedProtocol, Protocols, nameof(Protocols)));

        public SettingsViewModel SettingsViewModel { get; set; }

        public RelayCommand SaveOrder => new RelayCommand(async o => await actionHelper.SaveOrderAsync());

        public RelayCommand AddOrder => new RelayCommand(async o =>
        {
            await actionHelper.CreateNewOrderAsync(orderData);
            OrderNames = orderData.GetGetOrderNames();
            StatusMessage = "Added";
            NotifyPropertyChanged(nameof(StatusMessage));
        });

        public RelayCommand GetObjectName => new RelayCommand(o =>
        {
            var orderTuple = (OrderTuple)o;
            var order = orderData.GetById(orderTuple.Id);
            orderId = order.Id;
            ObjectData = order.ObjectData;
            NotifyPropertyChanged(nameof(ObjectData));
        });

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

            orderId = 1;

            orderData = new JsonOrderData(settings.SourceFolderPath);
            var order = orderData.GetById(orderId);

            OrderNames = orderData.GetGetOrderNames();

            StatusMessage = "Ready";

            ObjectData = order.ObjectData;
            Acts = new ObservableCollection<Act>(order.Acts);
            Protocols = new ObservableCollection<Protocol>(order.Protocols);
            Devices = new ObservableCollection<Device>(order.Devices);

            actionHelper = new ActionsHelper(moveAffirm, actionAffirm, inputAffirm);
        }
    }
}