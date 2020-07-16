using DocManager.Core;

namespace DocManager.ViewModel.Helpers
{
    internal static class ConvertFromViewModelHelper
    {
        public static Order ToOrder(this MainViewModel viewModel, int orderId)
        {
            return viewModel == null ? null : new Order
            {
                Id = orderId,
                ObjectData = viewModel.ObjectDataViewModel.ToObjectData(),
                Acts = viewModel.ActsViewModel.Acts,
                Protocols = viewModel.ProtocolViewModel.Protocols,
                Devices = viewModel.DevicesViewModel.Devices,
                WeatherDays = viewModel.WeatherDaysViewModel.WeatherDays,
            };
        }

        private static ObjectData ToObjectData(this ObjectDataViewModel viewModel)
        {
            return viewModel == null ? null : new ObjectData
            {
                Comment = viewModel.Comment,
                CustomerAddress = viewModel.CustomerAddress,
                CustomerName = viewModel.CustomerName,
                Inn = viewModel.Inn,
                Measurement = viewModel.Measurement,
                ObjectAddress = viewModel.ObjectAddress,
                ObjectName = viewModel.ObjectName,
                Ogrn = viewModel.Ogrn,
                Order = viewModel.Order,
                Purpose = viewModel.Purpose,
            };
        }
    }
}