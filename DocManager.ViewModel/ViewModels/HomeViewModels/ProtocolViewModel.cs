using DocManager.Core;
using DocManager.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DocManager.ViewModel
{
    public class ProtocolViewModel: PropertyChangedBase
    {
        private ObservableCollection<Protocol> protocols;

        private Protocol selectedProtocol;

        public Protocol SelectedProtocol
        {
            get => selectedProtocol;
            set
            {
                selectedProtocol = value;
                NotifyPropertyChanged(nameof(SelectedProtocol));
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

        public RelayCommand AddProtocol => new RelayCommand(o =>
        {
            if (!(o is string species))
            {
                return;
            }

            protocols.Add((new Protocol()).New(species, DateTime.Now, "123"));
            NotifyPropertyChanged(nameof(Protocols));
        });

        public RelayCommand RemoveProtocol => new RelayCommand(o =>
        {
            if (!(o is Protocol protocol))
            {
                return;
            }

            protocols.Remove(protocol);
            NotifyPropertyChanged(nameof(Protocols));
        });

        public ProtocolViewModel(IEnumerable<Protocol> protocols)
        {
            Protocols = new ObservableCollection<Protocol>(protocols);
        }
    }
}