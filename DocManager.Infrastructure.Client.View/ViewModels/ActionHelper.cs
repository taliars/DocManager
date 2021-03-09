using DocManager.Domain.Core.OrderEntities;
using DocManager.Domain.Interfaces;
using DocManager.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MyDocument = DocManager.Domain.Core.OrderEntities.Document;

namespace DocManager.Infrastructure.Client.ViewModel.Common
{
    public class ActionsHelper : PropertyChangedBase
    {
        private readonly Func<string, string, string> folderAffirm;
        private readonly Func<string, string, bool, Task<bool>> actionAffirm;
        private readonly Func<string, string, Task<string>> inputAffirm;
        private readonly IOrderData orderData;

        public ActionsHelper(SenderModel senderModel)
        {
            folderAffirm = senderModel.Move;
            actionAffirm = senderModel.Action;
            inputAffirm = senderModel.Input;
        }

        public void RemoveDocument(MyDocument document, ObservableCollection<MyDocument> collection, string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            collection.Remove(document);
        }

        public void AddDocument(ObservableCollection<MyDocument> collection, string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            collection.Add(new MyDocument());
        }

        public async Task MoveDocumentAsync(
            MyDocument document,
            ObservableCollection<MyDocument> documents,
            string name)
        {
            var newPath = folderAffirm(null, null);

            if (newPath == null)
            {
                return;
            }

            newPath = $"{newPath}\\{document.Name}.docx";

            try
            {
                await Task.Run(() => FileService.Move(document.Name, newPath));
                var tempProtocol = document;
                tempProtocol.Name = newPath;

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
                        break;
                    case "Source":
                        break;
                }
            });
        }

        public async Task OpenWithDefaultAppAsync(MyDocument document) 
        {
            await Task.Run(() => FileService.OpenWithDefaultApp(document?.Name));
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
                Documents = mainViewModel.Documents,
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
                    Name = ensure
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

        public static void PassOrderData(MainViewModel mainViewModel, Order order)
        {
            mainViewModel.ObjectData = order?.ObjectData ?? new ObjectData();
            mainViewModel.Documents = new ObservableCollection<Document>(order?.Documents ?? new List<MyDocument>());
            mainViewModel.Devices = new ObservableCollection<Device>(order?.Devices ?? new List<Device>());
            mainViewModel.WeatherDays = new ObservableCollection<WeatherDay>(order?.WeatherDays ?? new List<WeatherDay>());
        }

        public List<Order> GetGetOrderNames()
        {
            return orderData.GetOrderList().ToList();
        }
    }
}