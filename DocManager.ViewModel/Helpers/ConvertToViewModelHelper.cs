using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DocManager.ViewModel.Helpers
{
    internal static class ConvertToViewModelHelper
    {
        private static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            return collection == null ? null : new ObservableCollection<T>(collection);
        }
    }
}
