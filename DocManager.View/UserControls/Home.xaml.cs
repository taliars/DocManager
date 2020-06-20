using System.Windows.Controls;

namespace DocManager.View.UserControls
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            DataContextChanged += Home_DataContextChanged;
        }

        private void Home_DataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            var context = this.DataContext;
        }
    }
}
