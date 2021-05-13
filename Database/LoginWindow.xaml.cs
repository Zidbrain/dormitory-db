using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly DormitoriesContext _context;

        public LoginWindow()
        {
            InitializeComponent();

            _context = new DormitoriesContext();

            var binding = new Binding()
            {
                Source = _context.Группыпользователей.Select(item => item.Group).ToList()
            };
            UserTypeBox.SetBinding(ComboBox.ItemsSourceProperty, binding);
            UserTypeBox.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_context.Группыпользователей.Where(item => item.Group == UserTypeBox.Text).ToList()[0].Pass != InputBox.Password)
                MessageBox.Show("Неверный пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                Hide();
                var menu = new MainWindow(UserTypeBox.Text is "Admin");
                menu.Show();

                _context.Dispose();

                Close();

                //menu.WindowState = WindowState.Normal;
                //menu.Activate();
            }
        }
    }
}
