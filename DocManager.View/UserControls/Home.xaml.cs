using DocManager.ViewModel;
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
            this.DataContext = new MainViewModel();
        }
    }
}
