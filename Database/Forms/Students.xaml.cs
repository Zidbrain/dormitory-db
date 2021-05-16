using System.Linq;
using System.Windows.Controls;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Data;
using System.Globalization;
using System.Text.RegularExpressions;

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
            if (parameter is "true")
                return $"{valstr[..4]} {valstr[4..]}";
            else
                return $"+7({valstr[..3]}){valstr[3..6]}-{valstr[6..8]}-{valstr[8..]}";
        }
        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return null;

            var valstr = value as string;
            if (parameter is "true")
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

    public class StudentFormStub : FormBase<Студенты>
    {
        public StudentFormStub()
        {
        }
    }

    /// <summary>
    /// Interaction logic for Students.xaml
    /// </summary>
    public partial class Students : StudentFormStub
    {
        public static readonly DependencyProperty RoomSelectProperty = DependencyProperty.Register("RoomSelect", typeof(List<int?>), typeof(Students));
        public List<int?> RoomSelect
        {
            get => (List<int?>)GetValue(RoomSelectProperty);
            set => SetValue(RoomSelectProperty, value);
        }

        protected override void SetFields()
        {
            base.SetFields();
            var list = new List<int?>();
            foreach (var item in Context.Комнаты)
                list.Add(item.Номеркомнаты);
            RoomSelect = list;
        }

        public Students(DormitoriesContext context)
        {
            InitializeComponent();

            Initialize(addButton, RemoveButton, LeftButton, RightButton, context, static context => context.Студенты);

            SetFields();
        }

        protected override void RightButtonClick(object sender, RoutedEventArgs e)
        {
            base.RightButtonClick(sender, e);
            Searchbar.Text = "";
        }

        protected override void LeftButtonClick(object sender, RoutedEventArgs e)
        {
            base.LeftButtonClick(sender, e);
            Searchbar.Text = "";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Searchbar.Text != "")
            {
                foreach (var student in Items)
                    if (student.Фамилия.ToLower().StartsWith(Searchbar.Text.ToLower()))
                    {
                        Index = Items.FindIndex(item => item == student);
                        SetFields();
                        return;
                    }

                Item = new Студенты { Фамилия = "Фамилия", Имя = "Не", Отчетство = "Найдена!" };
            }
            else SetFields();
        }

        protected override void AddButtonClick(object sender, RoutedEventArgs e)
        {

            var student = new Студенты { Имя = "Имя", Фамилия = "Фамилия", Отчетство = "Отчество", Проживания = new Проживания { КомнатаId = RoomSelect[0] } };
            student.Проживания.Студенты = student;
            Context.Add(student.Проживания);
            Context.SaveChanges();

            Items = Context.Студенты.ToList();
            Index = Items.Count - 1;
            Item = Items[Index];
            SetFields();
        }

        protected override void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            Context.Remove(Item);
            Context.Remove(Item.Проживания);
            Context.SaveChanges();

            Items = Context.Студенты.ToList();
            if (Index >= Items.Count)
                Index = Items.Count - 1;

            Item = Items[Index];
            SetFields();
        }

        private void RoomID_NewOptionSelected(object sender, System.EventArgs e)
        {
            var window = new CreateRoomWindow(Context);
            if (window.ShowDialog() ?? false)
            {
                SetFields();
                RoomID.ItemsSource = RoomSelect;
                RoomID.SelectedItem = window.Item.Номеркомнаты;
            }
        }
    }
}
