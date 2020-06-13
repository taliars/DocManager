using DocManager.ViewModel;
using System.Windows.Controls;

namespace DocManager.View.UserControls
{
    /// <summary>
    /// Interaction logic for UserControl.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
            this.DataContext = new SettingsViewModel();
        }
    }
}
