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

namespace Database.Forms
{
    public class StudentDutiesConverter : IValueConverter 
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var id = (int)value;
            var context = (parameter as Duties).Context;
            return context.Find(typeof(Студенты), id);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return (value as Студенты).СтудентId;
        }
    }

    /// <summary>
    /// Interaction logic for Duties.xaml
    /// </summary>
    public partial class Duties : FormBase<Дежурства>
    {
        public static readonly DependencyProperty StudentProperty = DependencyProperty.Register("Student", typeof(Студенты), typeof(Duties));
        public Студенты Student 
        {
            get => (Студенты)GetValue(StudentProperty);
            set => SetValue(StudentProperty, value);
        }

        public Duties()
        {
            InitializeComponent();

            var binding = new Binding("СтудентId") { Source = Item, Converter = new StudentDutiesConverter(), ConverterParameter = this };
            BindingOperations.SetBinding(this, StudentProperty, binding);
        }

        private void ContentControl_Remove(object sender, RoutedEventArgs e) =>
            StandartRemove(sender as ContentControl);

        private void ContentControl_Add(object sender, RoutedEventArgs e) =>
            StandartAdd(sender as ContentControl);

    }
}
