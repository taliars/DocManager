using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DocManager.Core;
using DocManager.Data;
using DocManager.Data.Json;
using DocManager.Services;
using DocManager.ViewModel.Common;

namespace DocManager.ViewModel
{
    public class ActionsHelper : PropertyChangedBase
    {
        private readonly Func<string, string, string> folderAffirm;
        private readonly Func<string, string, bool, Task<bool>> actionAffirm;
        private readonly Func<string, string, Task<string>> inputAffirm;
        private readonly IOrderData orderData;

        public ActionsHelper(SenderModel senderModel, Settings settings)
        {
            this.folderAffirm = senderModel.Move;
            this.actionAffirm = senderModel.Action;
            this.inputAffirm = senderModel.Input;
            this.orderData = new JsonOrderData(settings.SourceFolderPath);
        }

        public void RemoveDocument<T>(object o, ObservableCollection<T> collection, string name) where T : Document, new()
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (!(o is T item))
            {
                return;
            }
            collection.Remove(item);
        }

        public void AddDocument<T>(object o, ObservableCollection<T> collection, string name) where T : Document, new()
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (!(o is string species))
            {
                return;
            }

            collection.Add(new T { Species = species });
        }

        public async Task MoveDocumentAsync<T>(
            T document,
            ObservableCollection<T> documents,
            string name) where T : Document
        {
            var newPath = folderAffirm(null, null);

            if (newPath == null)
            {
                return;
            }

            newPath = $"{newPath}\\{document.Name}.docx";

            try
            {
                await Task.Run(() => FileService.Move(document.Path, newPath));
                var tempProtocol = document;
                tempProtocol.Path = newPath;

                documents.Remove(document);
                documents.Add(tempProtocol);
                NotifyPropertyChanged(name);
            }
            catch (Exception e)
            {
                await actionAffirm("Ошибка", e.Message, true);
            }
        }

        public async Task Folder(string name)
        {
            var newPath = folderAffirm(null, null);

            if (newPath == null)
            {
                return;
            }

            await Task.Run(() =>
            {
                switch (name)
                {
                    case "Templates":
                        Properties.DocManager.Default.TemplatesPath = newPath;
                        break;
                    case "Source":
                        Properties.DocManager.Default.SourcePath = newPath;
                        break;
                }
                Properties.DocManager.Default.Save();
            });
        }

        public async Task OpenWithDefaultAppAsync<T>(T document) where T : Document
        {
            await Task.Run(() => FileService.OpenWithDefaultApp(document?.Path));
        }

        public async Task SaveOrderAsync(int orderId, MainViewModel mainViewModel)
        {
            var ensure = await actionAffirm("Сохранить?", "Сохранить внесенные изменения", false);

            if (!ensure)
            {
                return;
            }

            var order = new Order
            {
                Id = orderId,
                ObjectData = mainViewModel.ObjectData,
                Acts = mainViewModel.Acts,
                Protocols = mainViewModel.Protocols,
                Devices = mainViewModel.Devices,
                WeatherDays = mainViewModel.WeatherDays,
            };

            orderData.Update(order);
        }

        public async Task<Order> CreateNewOrderAsync()
        {
            var ensure = await inputAffirm("Новый заказ", "Введите номер заказа");

            if (string.IsNullOrEmpty(ensure))
            {
                return null;
            }

            var order = new Order
            {
                ObjectData = new ObjectData
                {
                    Order = ensure
                }
            };

            await Task.Run(() => orderData.Add(order));
            return order;
        }

        public Order GetById(int orderId, MainViewModel mainViewModel)
        {
            var order = orderData.GetById(orderId);
            PassOrderData(mainViewModel, order);
            mainViewModel.UpdateAll();

            return order;
        }

        public void PassOrderData(MainViewModel mainViewModel, Order order)
        {
            mainViewModel.ObjectData = order?.ObjectData ?? new ObjectData();
            mainViewModel.Acts = new ObservableCollection<Act>(order?.Acts ?? new List<Act>());
            mainViewModel.Protocols = new ObservableCollection<Protocol>(order?.Protocols ?? new List<Protocol>());
            mainViewModel.Devices = new ObservableCollection<Device>(order?.Devices ?? new List<Device>());
            mainViewModel.WeatherDays = new ObservableCollection<WeatherDay>(order?.WeatherDays ?? new List<WeatherDay>());
        }

        public List<OrderTuple> GetGetOrderNames()
        {
            return orderData?.GetGetOrderNames() ?? new List<OrderTuple>();
        }
    }
}
