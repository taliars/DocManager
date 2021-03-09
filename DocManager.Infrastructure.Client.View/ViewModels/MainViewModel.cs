using DocManager.Domain.Core.OrderEntities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MyDocument = DocManager.Domain.Core.OrderEntities.Document;

namespace DocManager.Infrastructure.Client.ViewModel.Common
{
    public class MainViewModel : PropertyChangedBase
    {
        private Document selectedDocument;

        private WeatherDay selectedWeatherDay;

        private Device selectedDevice;

        private Order currentOrder;

        private readonly ActionsHelper actionHelper;

        public string StatusMessage { get; set; }

        public List<Order> Orders { get; set; }

        public ObjectData ObjectData { get; set; }

        public ObservableCollection<Device> Devices { get; set; }

        public ObservableCollection<MyDocument> Documents { get; set; }

        public MyDocument SelectedDocument
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

        public ObservableCollection<WeatherDay> WeatherDays { get; set; }

        public RelayCommand AddDate => new RelayCommand(o =>
        {
            WeatherDays.Add(new WeatherDay());
            NotifyPropertyChanged(nameof(WeatherDays));
        });

        public RelayCommand RemoveDate => new(o =>
        {
            WeatherDays.Remove(SelectedWeatherDay);
            NotifyPropertyChanged(nameof(WeatherDays));
        });

        public RelayCommand OpenAct => new RelayCommand(async o => await actionHelper.OpenWithDefaultAppAsync(SelectedDocument));

        public RelayCommand Move => new RelayCommand(async o => await actionHelper.MoveDocumentAsync(SelectedDocument, Documents, nameof(Documents)));

        public RelayCommand Choose => new RelayCommand(async o =>
        {
            await actionHelper.Folder((string) o);
        });


        public RelayCommand SaveOrder => new RelayCommand(async o => await actionHelper.SaveOrderAsync(currentOrder.Id, this));

        public RelayCommand AddOrder => new RelayCommand(async o =>
        {
            currentOrder = await actionHelper.CreateNewOrderAsync();
            Orders = actionHelper.GetGetOrderNames();
            NotifyPropertyChanged(nameof(Orders));
        });

        public RelayCommand GetOrder => new RelayCommand(o => { currentOrder = actionHelper.GetById(((Order)o)?.Id ?? currentOrder.Id, this); });

        public RelayCommand AddDocument => new RelayCommand(o => actionHelper.AddDocument(Documents, nameof(Documents)));

        public RelayCommand RemoveDocument => new RelayCommand(o =>  actionHelper.RemoveDocument((MyDocument)o, Documents, nameof(Documents)));


        public MainViewModel(SenderModel senderModel)
        {
            actionHelper = new ActionsHelper(senderModel);

            currentOrder = actionHelper.GetById(1, this);

            Orders = actionHelper.GetGetOrderNames();

            StatusMessage = "Ready";
        }


        internal void UpdateAll()
        {
            string[] names =
            {
                nameof(Orders),
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

    }
}