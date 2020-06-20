namespace DocManager.View.UserControls
{
    /// <summary>
    /// Interaction logic for DeviceDataGrid.xaml
    /// </summary>
    public partial class DeviceDataGrid : System.Windows.Controls.UserControl
    {
        public DeviceDataGrid()
        {
            InitializeComponent();
            DataContextChanged += DeviceDataGrid_DataContextChanged;
        }

        private void DeviceDataGrid_DataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            var context = this.DataContext;
        }
    }
}
