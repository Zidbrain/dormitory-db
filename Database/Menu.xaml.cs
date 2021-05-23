using System.Windows.Controls;
using System.Windows;

namespace Database
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        private readonly MainWindow _mainWindow;

        public Menu(MainWindow mainWindow, bool isAdminPermissions)
        {
            InitializeComponent();

            _mainWindow = mainWindow;

            if (!isAdminPermissions)
            {
                EditDataButton.IsEnabled = false;
            }
        }

        private void EditDataButton_Click(object sender, System.Windows.RoutedEventArgs e) => _mainWindow.ContentControl.Content = new Forms.EditControl(_mainWindow);

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e) => _mainWindow.ContentControl.Content = new Reports(_mainWindow);

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            if (MessageBox.Show("Дейтвительно выйти?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Information) is MessageBoxResult.Yes)
                _mainWindow.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) => MessageBox.Show("Выполнил\nКузнецов Григорий Игоревич\nИУ5-43Б");

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _mainWindow.Hide();
            var login = new LoginWindow();
            login.Show();

            _mainWindow.Close();
        }
    }
}
