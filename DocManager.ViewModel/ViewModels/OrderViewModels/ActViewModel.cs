using DocManager.Core;
using DocManager.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DocManager.ViewModel
{
    public class ActViewModel: PropertyChangedBase
    {
        private Act selectedAct;

        private ObservableCollection<Act> acts;

        public Act SelectedAct
        {
            get => selectedAct;
            set
            {
                selectedAct = value;
                NotifyPropertyChanged(nameof(SelectedAct));
            }
        }

        public ObservableCollection<Act> Acts
        {
            get => acts;
            set
            {
                acts = value;
                NotifyPropertyChanged(nameof(Acts));
            }
        }

        public RelayCommand AddAct => new RelayCommand(o =>
        {
            if (!(o is string species))
            {
                return;
            }

            acts.Add(new Act().New(species, DateTime.Now, "123"));
            NotifyPropertyChanged(nameof(Acts));
        });

        public RelayCommand RemoveAct => new RelayCommand(o =>
        {
            if (!(o is Act act))
            {
                return;
            }

            acts.Remove(act);
            NotifyPropertyChanged(nameof(Acts));
        });

        public ActViewModel(IEnumerable<Act> acts)
        {
            Acts = new ObservableCollection<Act>(acts);
        }
    }
}