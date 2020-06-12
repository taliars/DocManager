using System.ComponentModel;

namespace DocManager.ViewModel.Common
{
    public class PropertyChangedBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}