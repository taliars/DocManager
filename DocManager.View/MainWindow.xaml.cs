using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;
using DocManager.ViewModel.ViewModels;
using Microsoft.WindowsAPICodePack.Dialogs;
using DialogCoordinator = DocManager.ViewModel.DialogCoordinator;

namespace DocManager.View
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DialogCoordinator.Create(Affirm, Input, Move);

            DataContext = new MainViewModel(DialogCoordinator.Instance);
        }

        private async Task<bool> Affirm(string title, string message, bool isAffirmativeOnly)
        {
            var messageDialogStyle = isAffirmativeOnly
                ? MessageDialogStyle.Affirmative
                : MessageDialogStyle.AffirmativeAndNegative;

            return MessageDialogResult.Affirmative
             == await this.ShowMessageAsync(title, message, messageDialogStyle, DialogSettings.Standard);
        }

        private async Task<string> Input(string title, string message)
        {
            return await this.ShowInputAsync(title, message, DialogSettings.Standard);
        }

        private static string Move(string defaultFileName, string title)
        {
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

        private void Home_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ordersFlyout.IsOpen = false;
        }
    }
}