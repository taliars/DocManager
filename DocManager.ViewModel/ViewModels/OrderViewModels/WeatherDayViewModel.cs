using DocManager.Core;
using DocManager.ViewModel.Common;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DocManager.ViewModel
{
    public class WeatherDayViewModel: PropertyChangedBase
    {
        private WeatherDay selectedWeatherDay;

        public WeatherDay SelectedWeatherDay
        {
            get => selectedWeatherDay;
            set
            {
                selectedWeatherDay = value;
                NotifyPropertyChanged(nameof(SelectedWeatherDay));
            }
        }

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

        public WeatherDayViewModel(IEnumerable<WeatherDay> weatherDays)
        {
            WeatherDays = new ObservableCollection<WeatherDay>(weatherDays);
        }
    }
}