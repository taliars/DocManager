using DocManager.Core;
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

        public static ObjectData ToObjectData(this ObjectDataViewModel viewModel)
        {
            return viewModel == null ? null : new ObjectData
            {
                ObjectName = viewModel.ObjectName,
                Comment = viewModel.Comment,
                CustomerAddress = viewModel.CustomerAddress,
                CustomerName = viewModel.CustomerName,
                Measurement = viewModel.Measurement,
                ObjectAddress = viewModel.ObjectAddress,
                Order = viewModel.Order,
                Purpose = viewModel.Purpose,
            };
        }
    }
}
