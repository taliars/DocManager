using MahApps.Metro.Controls;
using System.Linq;
using System.Windows.Controls;

namespace DocManager.View.UserControls.Flyouts
{
    /// <summary>
    /// Interaction logic for OrderListFlyout.xaml
    /// </summary>
    public partial class OrdersFlyout : Flyout
    {
        private int[] orders = { 1, 23, 45, 3, 2, 556, 3, 5, 45, 344, 444, 544, 556, 566 };

        public OrdersFlyout()
        {
            InitializeComponent();

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
    }
}
