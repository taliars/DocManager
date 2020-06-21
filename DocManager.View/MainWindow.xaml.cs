using DocManager.ViewModel;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace DocManager.View
{
    public partial class MainWindow : MetroWindow
    {
        private int[] orders = { 1, 23, 45, 3, 2, 556, 3, 5, 45, 344, 444, 544, 556, 566 };

        private MetroDialogSettings standardDialogSettings = new MetroDialogSettings
        {
            AffirmativeButtonText = "OK",
            NegativeButtonText = "Отмена",
            AnimateShow = false,
            AnimateHide = false,
        };

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(Confirm, Affirm, Move);

            foreach (int order in orders)
            {
                AllOrders.Items.Add(order);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox is null)
            {
                return;
            }

            string text = textBox.Text;

            AllOrders.Items.Clear();
            foreach (int order in orders.Where(o => o.ToString().StartsWith(text)))
            {
                AllOrders.Items.Add(order);
            }
        }

        async Task<bool> Confirm(string message, string caption)
        {
            return MessageDialogResult.Affirmative
             == await this.ShowMessageAsync(message, caption, MessageDialogStyle.AffirmativeAndNegative, standardDialogSettings);
        }

        async Task<bool> Affirm(string message, string caption)
        {
            return MessageDialogResult.Affirmative
             == await this.ShowMessageAsync(message, caption, MessageDialogStyle.Affirmative, standardDialogSettings);
        }

        string Move(string defaultFileName, string title)
        {
            defaultFileName = defaultFileName ?? "Выберите новое расположение файла";
            title = title ?? "Выберите папку";

            var dialog = new CommonOpenFileDialog
            {
                AllowNonFileSystemItems = true,
                Multiselect = true,
                IsFolderPicker = true,
                Title = title,
            };      

            return dialog.ShowDialog() == CommonFileDialogResult.Ok
                ? dialog.FileName
                : null;
        }
    }
}