using System.Collections.Generic;
using System.Collections.ObjectModel;
using DocManager.Core;

namespace DocManager.ViewModel
{
    internal static class Converter
    {
        public static InnerObjectDataViewModel ToInnerObjectDataViewModel(this ObjectData objectData)
        {
            return objectData == null
                ? null
                : new InnerObjectDataViewModel
                {
                    ObjectName = objectData.ObjectName,
                    ObjectAddress = objectData.ObjectAddress,
                    Measurement = objectData.Measurement,
                    Purpose = objectData.Purpose,
                    CustomerName = objectData.CustomerName,
                    CustomerAddress = objectData.CustomerAddress,
                    Order = objectData.Order,
                    Acts = objectData.Acts.ToObservableCollection(),
                    Protocols = objectData.Protocols.ToObservableCollection(),
                    Devices = objectData.Devices.ToObservableCollection(),
                    WeatherDays = objectData.WeatherDays.ToObservableCollection(),
                    Comment = objectData.Comment, 
                };
        }

        public static ObjectData ToObjectData(this InnerObjectDataViewModel viewModel)
        {
            return viewModel == null
                ? null
                : new ObjectData
                {
                    ObjectName = viewModel.ObjectName,
                    ObjectAddress = viewModel.ObjectAddress,
                    Measurement = viewModel.Measurement,
                    Purpose = viewModel.Purpose,
                    CustomerName = viewModel.CustomerName,
                    CustomerAddress = viewModel.CustomerAddress,
                    Order = viewModel.Order,
                    Acts = viewModel.Acts,
                    Protocols = viewModel.Protocols,
                    Devices = viewModel.Devices,
                    WeatherDays = viewModel.WeatherDays,
                    Comment = viewModel.Comment,
                };
        }

        private static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            return collection == null ? null : new ObservableCollection<T>(collection);
        }
    }
}
