using System.Windows.Controls;

namespace Database
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        private MainWindow _mainWindow;

        public Menu(MainWindow mainWindow, bool isAdminPermissions)
        {
            InitializeComponent();

            _mainWindow = mainWindow;

            if (!isAdminPermissions)
            {
                ViewQueriesButton.IsEnabled = false;
                EditDataButton.IsEnabled = false;
            }
        }

        private void EditDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _mainWindow.ContentControl.Content = new Forms.EditControl(_mainWindow);
        }
    }
}
