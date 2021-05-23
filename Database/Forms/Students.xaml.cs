using System.Linq;
using System.Windows.Controls;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data.Common;
using System.Data;

namespace Database.Forms
{
    public class BooleanConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if ((parameter as string) == "М")
                return (int)value == 1;
            else return (int)value == 2;
        }
        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if ((parameter as string) == "М")
                return (bool)value ? 1 : 2;
            else return (bool)value ? 2 : 1;
        }
    }

    public class PassportAndPhoneConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return null;

            var valstr = value as string;
            if (parameter is PassportAndPhoneConverterParameter.Passport)
                return $"{valstr[..4]} {valstr[4..]}";
            else
                return $"+7({valstr[..3]}){valstr[3..6]}-{valstr[6..8]}-{valstr[8..]}";
        }
        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return null;

            var valstr = value as string;
            if (parameter is PassportAndPhoneConverterParameter.Passport)
            {
                if (!Regex.IsMatch(valstr, @"\A\d{4}\s\d{6}\z"))
                    throw new System.FormatException();

                return $"{valstr[0..4]}{valstr[5..]}";
            }
            else
            {
                if (!Regex.IsMatch(valstr, @"\A\+7\(\d{3}\)\d{3}-\d{2}-\d{2}\z"))
                    throw new System.FormatException();

                return $"{valstr[3..6]}{valstr[7..10]}{valstr[11..13]}{valstr[14..]}";
            }
        }
    }

    public enum PassportAndPhoneConverterParameter
    {
        Passport, Phone
    }

    public class RegexValidation : ValidationRule
    {
        public string RegexExpression { get; set; }

        public string Error { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Regex.IsMatch(value as string, RegexExpression))
                return ValidationResult.ValidResult;
            return new ValidationResult(false, Error);
        }
    }

    /// <summary>
    /// Interaction logic for Students.xaml
    /// </summary>
    public partial class Students : FormBase<Студенты>
    {
        public static readonly DependencyProperty RoomSelectProperty = DependencyProperty.Register("RoomSelect", typeof(List<int?>), typeof(Students));
        public List<int?> RoomSelect
        {
            get => (List<int?>)GetValue(RoomSelectProperty);
            set => SetValue(RoomSelectProperty, value);
        }

        private Binding _binding;

        public Students()
        {
            InitializeComponent();

            _binding = new Binding("SelectedItem") { Source = control, Mode = BindingMode.OneWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
            BindingOperations.SetBinding(this, ItemProperty, _binding);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Searchbar.Text != "")
            {
                for (int i = 0; i < control.Items.Count; i++)
                {
                    var student = control.Items[i] as Студенты;
                    if (student.Фамилия.ToLower().StartsWith(Searchbar.Text.ToLower()))
                    {
                        control.Index = i;
                        return;
                    }
                }

                Item = new Студенты { Фамилия = "Фамилия", Имя = "Не", Отчетство = "Найдена!" };
            }
            else
                Item = control.SelectedItem as Студенты;
        }

        private void RoomID_NewOptionSelected(object sender, System.EventArgs e)
        {
            var window = new CreateRoomWindow(Context);
            if (window.ShowDialog() ?? false)
            {
                MakeList();
                RoomID.ItemsSource = RoomSelect;
                RoomID.SelectedItem = window.Item.НомерКомнаты;
            }
        }

        private void MakeList()
        {
            var list = new List<int?>();
            foreach (var item in Context.Комнаты)
                list.Add(item.НомерКомнаты);
            RoomSelect = list;
        }

        private void Control_SelectedItemChanged(object sender, System.EventArgs e)
        {
            MakeList();
            BindingOperations.SetBinding(this, ItemProperty, _binding);
        }

        private void Control_Add(object sender, RoutedEventArgs e)
        {
            var student = new Студенты { Имя = "Имя", Фамилия = "Фамилия", Отчетство = "Отчество", Проживания = new Проживания { КомнатаId = RoomSelect[0] } };
            student.Проживания.Студенты = student;
            Context.Add(student.Проживания);
            Context.SaveChanges();

            control.Items = Context.Студенты.ToList();
            control.Index = control.Items.Count - 1;
        }

        private void Control_Remove(object sender, RoutedEventArgs e)
        {
            Context.Remove(Item);
            Context.Remove(Item.Проживания);
            Context.SaveChanges();

            control.Items = Context.Студенты.ToList();
            if (control.Index >= control.Items.Count)
                control.Index = control.Items.Count - 1;
        }
    }
}
