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

namespace Database.Forms
{
    /// <summary>
    /// Interaction logic for CreateFloor.xaml
    /// </summary>
    public partial class CreateFloor : Window
    {
        private readonly DormitoriesContext _context;

        public static readonly DependencyProperty ItemProperty = DependencyProperty.Register("Item", typeof(Этажи), typeof(CreateFloor));
        public Этажи Item
        {
            get => (Этажи)GetValue(ItemProperty);
            set => SetValue(ItemProperty, value);
        }

        public CreateFloor(DormitoriesContext context)
        {
            InitializeComponent();

            _context = context;

            Item = new Этажи
            {
                ЭтажId = 0,
                НаличиеДуша = false,
                НаличиеКухни = false
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (_context.Этажи.Find(Item.ЭтажId) is not null)
            {
                MessageBox.Show("Этаж с данным ЭтажID уже существет", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
            _context.Add(Item);
            _context.SaveChanges();
            Close();
        }
    }
}
