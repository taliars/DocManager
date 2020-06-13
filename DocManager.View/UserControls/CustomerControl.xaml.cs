using MahApps.Metro.Controls.Dialogs;

namespace DocManager.View.UserControls
{
    /// <summary>
    /// Interaction logic for CustomerInfo.xaml
    /// </summary>
    public partial class Customer : System.Windows.Controls.UserControl
    {
        public Customer()
        {
            InitializeComponent();
        }

        public delegate void TextBoxKeyDown(object sender, System.Windows.Input.KeyEventArgs e);

        public event TextBoxKeyDown TextBoxKeyDownChanged;

        private void TextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBoxKeyDownChanged?.Invoke(sender, e);
        }
    }
}
