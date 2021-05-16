using System.Windows;
using System.Windows.Controls;

namespace Database.Forms
{
    /// <summary>
    /// Interaction logic for EditControl.xaml
    /// </summary>
    public partial class EditControl : UserControl
    {
        private readonly DormitoriesContext _context;
        private readonly MainWindow _window;

        public EditControl(MainWindow window)
        {
            InitializeComponent();

            _context = new DormitoriesContext();

            _window = window;

            (TabControl.Items[0] as TabItem).Content = new Students(_context);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _context.Dispose();
            _window.ContentControl.Content = _window.Menu;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) => _context.SaveChanges();
    }
}
