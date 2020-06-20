using DocManager.ViewModel;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DocManager.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private int[] orders = { 1, 23, 45, 3, 2, 556, 3, 5, 45, 344, 444, 544, 556, 566 };


        public MainWindow()
        {
            InitializeComponent();

            var mySettings = new MetroDialogSettings
            {
                AffirmativeButtonText = "OK",
                NegativeButtonText = "Отмена",
                AnimateShow = false,
                AnimateHide = false,
            };

            async Task<bool> Confirm(string msg, string capt)
            {
                return MessageDialogResult.Affirmative
                 == await this.ShowMessageAsync(msg, capt, MessageDialogStyle.AffirmativeAndNegative, mySettings);
            }

            DataContext = new MainViewModel(Confirm);

            foreach (int order in orders)
            {
                AllOrders.Items.Add(order);
            }
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
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
    }
}