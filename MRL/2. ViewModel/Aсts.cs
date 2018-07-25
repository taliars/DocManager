using System;
using System.ComponentModel;
using MRL.Model;

namespace MRL.ViewModel
{
    class Acts: Act
    {
        public string Species
        {
            get { return _species; }
            set
            {
                if (_species != value)
                {
                    _species = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Species"));
                }
            }
        }
        public string Name
        {
            get { return _name; };
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Name"));
                }
            }
        }
        public string Date
        {
            get { return _date; };
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Name"));
                }
            }
        }
        public string Dates
        {
            get { return _dates; }
            set
            {
                if (_dates != value)
                {
                    _dates = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Dates"));
                }
            }
        }
        public string Perfomer
        {
            get { return _perfomer; };
            set
            {
                if (_perfomer != value)
                {
                    _perfomer = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Perfomer"));
                }
            }
        }

        public void AddNew(string species)
        {
            switch (species)
            {
                case "Шум":
                    Name = "шм";
                    break;

                case "Инфрзвук":
                    Name = "иф";
                    break;

                case "Вибрация":
                    Name = "вб";
                    break;

                case "ЭМИ 50 Гц":
                    Name = "эм";
                    break;

                case "Радиация":
                    Name = "рн";
                    break;

                case "Радионуклиды":
                    Name = "рн";
                    break;

                case "Почва":
                    Name = "пч";
                    break;

                case "Вода":
                    Name = "пв";
                    break;

                case "Воздух":
                    Name = "ав";
                    break;

                default:
                    break;
            }
        }
    }
}
