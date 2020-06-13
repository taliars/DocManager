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
        public MainViewModel viewModel;

        private bool _shutdown;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainViewModel();
            this.DataContext = viewModel;
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
            var result = await this.ShowMessageAsync("Выйти из приложение",
                "Есть не сохраненные данные. Отменить изменения и выйти?",
                MessageDialogStyle.AffirmativeAndNegative, mySettings);

            _shutdown = result == MessageDialogResult.Affirmative;
            if (_shutdown)
            {
                viewModel.ObjectData.Save();
                Environment.Exit(0);
            }
        }

        private async void Customer_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var s = (sender as TextBox)?.Text;

            if (viewModel.ObjectData.Order == "125")
            {
                return;
            }

            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Создать",
                NegativeButtonText = "Отмена",
                AnimateShow = true,
                AnimateHide = false
            };
            var result = await this.ShowMessageAsync("Заказ не найден",
                "Заказ с указанным номером не найден. Создать новый?",
                MessageDialogStyle.AffirmativeAndNegative, mySettings);

            var decision = result == MessageDialogResult.Affirmative;
        }

        private void HamburgerMenuControl_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.HamburgerMenuControl.Content = e.ClickedItem;
            this.HamburgerMenuControl.IsPaneOpen = false;
        }
    }
}
