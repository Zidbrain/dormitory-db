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
using System.Windows.Shapes;

namespace Database
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Menu Menu { get; init; }

        public MainWindow(bool isAdminPremissions)
        {
            InitializeComponent();

            Menu = new Menu(this, isAdminPremissions);

            ContentControl.Content = Menu;
        }

        public MainWindow() : this(true) { }
    }
}
