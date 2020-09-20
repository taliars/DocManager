using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocManager.Core;
using DocManager.ViewModel.Common;

namespace DocManager.ViewModel.ViewModels
{
    public class WeatherDaysViewModel : PropertyChangedBase
    {
        private WeatherDay selectedWeatherDay;

        public ObservableCollection<WeatherDay> WeatherDays { get; set; }

        public RelayCommand AddDate { get; }

        public RelayCommand RemoveDate { get; }


        public WeatherDay SelectedWeatherDay
        {
            get => selectedWeatherDay;
            set
            {
                selectedWeatherDay = value;
                NotifyPropertyChanged(nameof(SelectedWeatherDay));
            }
        }

        public WeatherDaysViewModel()
        {
            AddDate = new RelayCommand(o =>
            {
                WeatherDays.Add(new WeatherDay());
                NotifyPropertyChanged(nameof(WeatherDays));
            });

            RemoveDate = new RelayCommand(o =>
            {
                WeatherDays.Remove(SelectedWeatherDay);
                NotifyPropertyChanged(nameof(WeatherDays));
            });
        }
    }
}
}
