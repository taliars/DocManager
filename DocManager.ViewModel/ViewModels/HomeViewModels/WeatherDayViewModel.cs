using DocManager.Core;
using DocManager.ViewModel.Common;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DocManager.ViewModel
{
    public class WeatherDayViewModel: PropertyChangedBase
    {
        private WeatherDay selectedWeatherDay;
        private ObservableCollection<WeatherDay> weatherDays;

        public WeatherDay SelectedWeatherDay
        {
            get => selectedWeatherDay;
            set
            {
                selectedWeatherDay = value;
                NotifyPropertyChanged(nameof(SelectedWeatherDay));
            }
        }

        public ObservableCollection<WeatherDay> WeatherDays
        {
            get => weatherDays;
            set
            {
                weatherDays = value;
                NotifyPropertyChanged(nameof(WeatherDays));
            }
        }

        public RelayCommand AddDate => new RelayCommand(o =>
        {
            weatherDays.Add(new WeatherDay());
            NotifyPropertyChanged(nameof(WeatherDays));
        });

        public RelayCommand RemoveDate => new RelayCommand(o =>
        {
            weatherDays.Remove(SelectedWeatherDay);
            NotifyPropertyChanged(nameof(WeatherDays));
        });

        public WeatherDayViewModel(IEnumerable<WeatherDay> weatherDays)
        {
            WeatherDays = new ObservableCollection<WeatherDay>(weatherDays);
        }
    }
}