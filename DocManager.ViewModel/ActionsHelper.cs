using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DocManager.Core;
using DocManager.Data;
using DocManager.Services;
using DocManager.ViewModel.Common;

namespace DocManager.ViewModel
{
    public class ActionsHelper : PropertyChangedBase
    {
        private readonly Func<string, string, string> moveAffirm;
        private readonly Func<string, string, bool, Task<bool>> actionAffirm;
        private readonly Func<string, string, Task<string>> inputAffirm;

        public ActionsHelper(
            Func<string, string, string> moveAffirm,
            Func<string, string, bool, Task<bool>> actionAffirm,
            Func<string, string, Task<string>> inputAffirm)
        {
            this.moveAffirm = moveAffirm;
            this.actionAffirm = actionAffirm;
            this.inputAffirm = inputAffirm;
        }

        public void RemoveDocument<T>(object o, ObservableCollection<T> collection, string name) where T : Document, new()
        {
            if (!(o is T item))
            {
                return;
            }
            collection.Remove(item);
            NotifyPropertyChanged(name);
        }

        public void AddDocument<T>(object o, ObservableCollection<T> collection, string name) where T : Document, new()
        {
            if (!(o is string species))
            {
                return;
            }

            collection.Add(new T { Species = species });
            NotifyPropertyChanged(name);
        }

        public async Task MoveDocument<T>(
            T document,
            ObservableCollection<T> documents,
            string name) where T : Document
        {
            var newPath = moveAffirm(null, null);

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

        public async Task OpenWithDefaultApp<T>(T document) where T : Document
        {
            await Task.Run(() => FileService.OpenWithDefaultApp(document?.Path));
        }

        public async Task SaveOrderAsync()
        {
            var ensure = await actionAffirm("Сохранить?", "Сохранить внесенные изменения", false);

            if (!ensure)
            {
                return;
            }

            // TODO: Implement save logic
        }

        public async Task<IOrderData> CreateNewOrderAsync(IOrderData orderData)
        {
            var ensure = await inputAffirm("Новый заказ", "Введите номер заказа");

            if (string.IsNullOrEmpty(ensure))
            {
                return orderData;
            }

            var order = new Order
            {
                ObjectData = new ObjectData
                {
                    Order = ensure
                }
            };

            await Task.Run(() => orderData.Add(order));
            return orderData;
        }
    }
}
