namespace DocManager.View.UserControls
{
    /// <summary>
    /// Interaction logic for TabDeviceAndMeteo.xaml
    /// </summary>
    public partial class TabControlDeviceMeteo : System.Windows.Controls.UserControl
    {
        public TabControlDeviceMeteo()
        {
            InitializeComponent();
            DataContextChanged += TabControlDeviceMeteo_DataContextChanged;
        }

        private void TabControlDeviceMeteo_DataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            var context = this.DataContext;
        }
    }
}
