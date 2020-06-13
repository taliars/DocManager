using DocManager.ViewModel;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Windows.Controls;

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

            this.Closing += MainWindow_Closing;
            this.HamburgerMenuControl.SelectedIndex = 0;
        }

        private async void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !_shutdown;
            if (_shutdown) return;
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Выйти",
                NegativeButtonText = "Отмена",
                AnimateShow = false,
                AnimateHide = false
            };
            var result = await this.ShowMessageAsync("Выйти из приложения",
                "Есть не сохраненные данные. Отменить изменения и выйти?",
                MessageDialogStyle.AffirmativeAndNegative, mySettings);

            _shutdown = result == MessageDialogResult.Affirmative;
            if (_shutdown)
            {
                Environment.Exit(0);
            }
        }

        private void HamburgerMenuControl_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.HamburgerMenuControl.Content = e.ClickedItem;
            this.HamburgerMenuControl.IsPaneOpen = false;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.HamburgerMenuControl.SelectedIndex = 1;
            this.HamburgerMenuControl.Content = HamburgerMenuControl.Items[1];
        }
    }
}
