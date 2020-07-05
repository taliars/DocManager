using DocManager.Core;
using DocManager.ViewModel.Common;
using System.Collections.ObjectModel;

namespace DocManager.ViewModel
{
    public class ActViewModel: PropertyChangedBase
    {
        private Act selected;

        private readonly Order orderData;

        public Act Selected
        {
            get => selected;
            set
            {
                selected = value;
                NotifyPropertyChanged(nameof(Selected));
            }
        }

        public ObservableCollection<Act> Acts { get; set; }

        public RelayCommand Add => new RelayCommand(o =>
        {
            if (!(o is string species))
            {
                return;
            }

            Acts.Add(new Act());
            NotifyPropertyChanged(nameof(Acts));
        });

        public RelayCommand Remove => new RelayCommand(o =>
        {
            if (!(o is Act act))
            {
                return;
            }

            Acts.Remove(act);
            NotifyPropertyChanged(nameof(Acts));
        });

        public ActViewModel(Order orderData)
        {
            Acts = new ObservableCollection<Act>(orderData.Acts);
            this.orderData = orderData;
        }
    }
}