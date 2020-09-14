using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DocManager.Abstractions;
using DocManager.Core;
using DocManager.Data;
using DocManager.Data.Json;
using DocManager.Services;
using DocManager.ViewModel.Common;

namespace DocManager.ViewModel
{
    public class ActionHelper : PropertyChangedBase, IActionHelper
    {
        private readonly IDialogCoordinator dialogCoordinator;
        private readonly IOrderData orderData;

        public ActionHelper(IDialogCoordinator dialogCoordinator, Settings settings)
        {
            this.dialogCoordinator = dialogCoordinator;
            orderData = new JsonOrderData(settings.SourceFolderPath);
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

        public async Task MoveDocumentAsync<T>(T document, ObservableCollection<T> documents, string name) where T : Document
        {
            var newPath = dialogCoordinator.Move(null, null);

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
                await dialogCoordinator.Affirm("Ошибка", e.Message, true);
            }
        }

        public async Task UpdatePropertiesFolder(string name)
        {
            var newPath = dialogCoordinator.Move(null, null);

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
            try
            {
                await Task.Run(() => FileService.OpenWithDefaultApp(document?.Path));
            }
            catch (Exception e)
            {
                await dialogCoordinator.Affirm("Ошибка", e.Message, true);
            }
        }

        public async Task SaveOrderAsync(int orderId, Order order)
        {
            var ensure = await dialogCoordinator.Affirm("Сохранить?", "Сохранить внесенные изменения", false);

            if (!ensure)
            {
                return;
            }

            orderData.Update(order);
        }

        public async Task<Order> CreateNewOrderAsync()
        {
            var ensure = await dialogCoordinator.Input("Новый заказ", "Введите номер заказа");

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

        public Order GetById(int orderId)
        {
            return orderData.GetById(orderId);
        }

        public List<OrderTuple> GetGetOrderNames()
        {
            return orderData?.GetGetOrderNames() ?? new List<OrderTuple>();
        }
    }
}
