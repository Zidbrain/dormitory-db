using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace Database.Forms
{
    public class DbSetConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((Type)parameter == typeof(Студенты))
                return (value as DbSet<Студенты>).Select(static item => item.СтудентId).ToList();
            else if ((Type)parameter == typeof(Комнаты))
                return (value as DbSet<Комнаты>).ToList();
            else if ((Type)parameter == typeof(Гости))
                return (value as DbSet<Гости>).ToList();
            return value;
        }
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }

    /// <summary>
    /// Interaction logic for Rooms.xaml
    /// </summary>
    public partial class Rooms : FormBase<Комнаты>
    {
        protected override void OnContextChanged(DormitoriesContext oldContext, DormitoriesContext newContext) =>
            ComboBoxColumn.ItemsSource = newContext.Этажи.Select(static item => item.ЭтажId).ToList();

        public static readonly DependencyProperty ItemsListProperty = DependencyProperty.Register("ItemsList", typeof(List<Комнаты>), typeof(Rooms));
        public List<Комнаты> ItemsList
        {
            get => (List<Комнаты>)GetValue(ItemsListProperty);
            set => SetValue(ItemsListProperty, value);
        }
        public Rooms()
        {
            InitializeComponent();
            Initialize(null, null, null, null, static context => context.Комнаты);
        }
    }
}
