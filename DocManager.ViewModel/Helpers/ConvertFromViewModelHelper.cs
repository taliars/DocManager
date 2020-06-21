using DocManager.Core;

namespace DocManager.ViewModel.Helpers
{
    internal static class ConvertFromViewModelHelper
    {
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
