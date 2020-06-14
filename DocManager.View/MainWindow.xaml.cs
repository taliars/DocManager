using DocManager.ViewModel;
using MahApps.Metro.Controls;

namespace DocManager.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private bool _shutdown;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
         
        }

        private async void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //    e.Cancel = !_shutdown;
            //    if (_shutdown) return;
            //    var mySettings = new MetroDialogSettings()
            //    {
            //        AffirmativeButtonText = "Выйти",
            //        NegativeButtonText = "Отмена",
            //        AnimateShow = false,
            //        AnimateHide = false
            //    };
            //    var result = await this.ShowMessageAsync(
            //        "Выйти из приложения",
            //        "Есть не сохраненные данные. Отменить изменения и выйти?",
            //        MessageDialogStyle.AffirmativeAndNegative,
            //        mySettings);

            //    _shutdown = result == MessageDialogResult.Affirmative;
            //    if (_shutdown)
            //    {
            //        Environment.Exit(0);
            //    }
        }

    }
}
