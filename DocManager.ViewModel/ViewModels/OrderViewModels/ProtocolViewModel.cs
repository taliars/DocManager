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

        private Protocol selected;

        private readonly Func<string, string, string> move;
        private readonly Func<string, string, Task<bool>> affirm;

        public ObservableCollection<Protocol> Protocols { get; set; }

        public Protocol Selected
        {
            get => selected;
            set
            {
                selected = value;
                NotifyPropertyChanged(nameof(Selected));
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

            await Task.Run(() => WordService.WriteWord(orderData, protocol, species));

            Protocols.Add(protocol);
        });

        public RelayCommand Remove => new RelayCommand(o =>
        {
            if (!(o is Protocol protocol))
            {
                return;
            }

            Protocols.Remove(protocol);
            NotifyPropertyChanged(nameof(Protocols));
        });

        public RelayCommand Open => new RelayCommand(o => FileService.OpenWithDefaultApp(Selected?.Path));

        public RelayCommand Move => new RelayCommand(async o =>
        {
            var newPath = move(null, null);

            if (newPath == null)
            {
                return;
            }

            newPath = $"{newPath}\\{Selected.Name}.docx";

            try
            {
                await Task.Run(() => FileService.Move(Selected.Path, newPath));
                var tempProtocol = Selected;
                tempProtocol.Path = newPath;

                Protocols.Remove(Selected);
                Protocols.Add(tempProtocol);
                NotifyPropertyChanged(nameof(Protocols));
            }
            catch (Exception e)
            {
                await affirm("Ошибка", e.Message);
                return;
            }
        });


        public ProtocolViewModel(OrderData orderData, Func<string, string, string> move, Func<string, string, Task<bool>> affirm)
        {
            Protocols = new ObservableCollection<Protocol>(orderData.Protocols);
            this.orderData = orderData;
            this.move = move;
            this.affirm = affirm;
        }
    }
}