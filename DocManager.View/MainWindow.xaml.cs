using DocManager.ViewModel;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace DocManager.View
{
    public partial class MainWindow : MetroWindow
    {
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
            DataContext = new MainViewModel(AffirmAction, InputAction, Move);    
        }

        async Task<bool> AffirmAction(string message, string caption, bool isAffimativeOnly)
        {
            var messageDialogStyle = isAffimativeOnly
                ? MessageDialogStyle.Affirmative
                : MessageDialogStyle.AffirmativeAndNegative;

            return MessageDialogResult.Affirmative
             == await this.ShowMessageAsync(message, caption, messageDialogStyle, standardDialogSettings);          
        }

        async Task<bool> InputAction(string message, string caption)
        {
            return string.Empty
                != await this.ShowInputAsync(message, caption, standardDialogSettings);
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