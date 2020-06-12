using DocManager.ViewModel;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace DocManager.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainViewModel viewModel;

        private bool _shutdown;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainViewModel();
            this.DataContext = viewModel;
            this.Closing += MainWindow_Closing;
        }

        private async void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !_shutdown;
            if (_shutdown) return;
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Quit",
                NegativeButtonText = "Cancel",
                AnimateShow = true,
                AnimateHide = false
            };
            var result = await this.ShowMessageAsync("Quit application?",
                "Sure you want to quit application?",
                MessageDialogStyle.AffirmativeAndNegative, mySettings);

            _shutdown = result == MessageDialogResult.Affirmative;
            if (_shutdown)
            {
                viewModel.ObjectData.Save();
            }
        }
    }
}
