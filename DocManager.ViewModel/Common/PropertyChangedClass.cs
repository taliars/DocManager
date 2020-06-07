using System.ComponentModel;

namespace DocManager.ViewModel.Common
{
    public class PropertyChangedClass
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}