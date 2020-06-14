using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DocManager.ViewModel
{
    internal static class Converter
    {
        private static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            return collection == null ? null : new ObservableCollection<T>(collection);
        }
    }
}
