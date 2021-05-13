using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Database.Forms
{
    /// <summary>
    /// Interaction logic for EditControl.xaml
    /// </summary>
    public partial class EditControl : UserControl
    {
        private DormitoriesContext _context;
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
    }
}
