using DocManager.ViewModel;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace DocManager.View
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel(
                new SenderModel
                {
                    Action = AffirmAction,
                    Input = InputAction,
                    Move = Move,
                });
        }

        private async Task<bool> AffirmAction(string message, string caption, bool isAffirmativeOnly)
        {
            var messageDialogStyle = isAffirmativeOnly
                ? MessageDialogStyle.Affirmative
                : MessageDialogStyle.AffirmativeAndNegative;

            return MessageDialogResult.Affirmative
             == await this.ShowMessageAsync(message, caption, messageDialogStyle, DialogSettings.Standard);
        }

        private async Task<string> InputAction(string message, string caption)
        {
            return await this.ShowInputAsync(message, caption, DialogSettings.Standard);
        }

        private string Move(string defaultFileName, string title)
        {
            _ = defaultFileName ?? "Выберите новое расположение файла";
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