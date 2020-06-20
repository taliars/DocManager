using DocManager.Core;
using DocManager.Services;
using DocManager.ViewModel.Common;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DocManager.ViewModel
{
    public class ProtocolViewModel : PropertyChangedBase
    {
        private readonly OrderData orderData;

        private ObservableCollection<Protocol> protocols;

        private Protocol selected;

        public Protocol Selected
        {
            get => selected;
            set
            {
                selected = value;
                NotifyPropertyChanged(nameof(Selected));
            }
        }

        public ObservableCollection<Protocol> Protocols
        {
            get => protocols;
            set
            {
                protocols = value;
                NotifyPropertyChanged(nameof(Protocols));
            }
        }

        public RelayCommand Add => new RelayCommand(async o =>
        {
            if (!(o is string species)) { return; }

            var protocol = new Protocol
            {
                Date = DateTime.Now,
                Dates = DateTime.Now.ToShortDateString(),
                Name = Protocol.GetName(species, orderData.ObjectData.Order),
                Perfomer = "Астахов",
                Species = species
            };

            await Task.Run(() =>
            {
                WordService.WriteWord(orderData, protocol, species);
            });

            protocols.Add(protocol);

            NotifyPropertyChanged(nameof(Protocols));
        });

        public RelayCommand Remove => new RelayCommand(o =>
        {
            if (!(o is Protocol protocol))
            {
                return;
            }

            protocols.Remove(protocol);
            NotifyPropertyChanged(nameof(Protocols));
        });

        public RelayCommand Open => new RelayCommand(o =>
        {
            if (Selected?.Path != null)
            {
                System.Diagnostics.Process.Start($"{Selected.Path}.docx");
            }
        });

        public ProtocolViewModel(OrderData orderData)
        {
            Protocols = new ObservableCollection<Protocol>(orderData.Protocols);
            this.orderData = orderData;
        }
    }
}