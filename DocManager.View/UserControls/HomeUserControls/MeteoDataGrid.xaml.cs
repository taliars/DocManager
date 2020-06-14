namespace DocManager.View.UserControls
{
    /// <summary>
    /// Interaction logic for MeteoDataGrid.xaml
    /// </summary>
    public partial class MeteoDataGrid : System.Windows.Controls.UserControl
    {
        public MeteoDataGrid()
        {
            InitializeComponent();
            DataContextChanged += MeteoDataGrid_DataContextChanged;
        }

        private void MeteoDataGrid_DataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            var context = this.DataContext;
        }
    }
}
