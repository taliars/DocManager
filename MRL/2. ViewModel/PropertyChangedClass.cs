using System;
using System.ComponentModel;

namespace MRL.ViewModel
{
    public class PropertyChangedClass
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
