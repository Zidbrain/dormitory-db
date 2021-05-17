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
    /// Interaction logic for CreateRoom.xaml
    /// </summary>
    public partial class CreateRoomWindow : Window
    {
        public static readonly DependencyProperty ItemProperty = DependencyProperty.Register("Item", typeof(Комнаты), typeof(CreateRoomWindow));
        public Комнаты Item
        {
            get => (Комнаты)GetValue(ItemProperty);
            set => SetValue(ItemProperty, value);
        }

        public static readonly DependencyProperty FloorSelectProperty = DependencyProperty.Register("FloorSelect", typeof(List<int?>), typeof(CreateRoomWindow));
        public List<int?> FloorSelect
        {
            get => (List<int?>)GetValue(FloorSelectProperty);
            set => SetValue(FloorSelectProperty, value);
        }

        protected DormitoriesContext Context { get; init; }

        public CreateRoomWindow() : this(null) { }

        public CreateRoomWindow(DormitoriesContext context)
        {
            InitializeComponent();

            Context = context;
            if (Context is null)
                return;

            var list = new List<int?>();
            foreach (var item in Context.Этажи)
                list.Add(item.ЭтажId);

            FloorSelect = list;

            Item = new Комнаты
            {
                Количествомест = 1,
                Номеркомнаты = 0,
                ЭтажId = FloorSelect[0]
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Context.Комнаты.Find(Item.Номеркомнаты) is not null)
            {
                MessageBox.Show("Комната с данным номером уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;

            Context.Add(Item);
            Context.SaveChanges();

            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void ExtendedComboBox_NewOptionSelected(object sender, EventArgs e)
        {
            var window = new CreateFloor(Context);
            if (window.ShowDialog() ?? false)
            {
                var list = new List<int?>();
                foreach (var item in Context.Этажи)
                    list.Add(item.ЭтажId);

                FloorSelect = list;
                FloorComboBox.ItemsSource = FloorSelect;
                FloorComboBox.SelectedItem = window.Item.ЭтажId;
            }
        }
    }
}
