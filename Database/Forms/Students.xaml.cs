using System.Linq;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Text;
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

    /// <summary>
    /// Interaction logic for Students.xaml
    /// </summary>
    public partial class Students : UserControl
    {
        private int _index;
        private readonly DormitoriesContext _context;
        private List<Студенты> _students;

        private readonly DependencyProperty _studentDependency = DependencyProperty.Register("Student", typeof(Студенты), typeof(Students));
        protected Студенты Student
        {
            get => (Студенты)GetValue(_studentDependency);
            set => SetValue(_studentDependency, value);
        }

        private readonly DependencyProperty _roomSelectDependency = DependencyProperty.Register("RoomSelect", typeof(List<int?>), typeof(Students));
        protected List<int?> RoomSelect
        {
            get => (List<int?>)GetValue(_roomSelectDependency);
            set => SetValue(_roomSelectDependency, value);
        }
        private void SetFields()
        {
            _students = _context.Студенты.ToList();
            var student = _students.ElementAt(_index);
            var list = new List<int?>();
            foreach (var item in _context.Проживания.Select(static item => item.КомнатаId))
            {
                if (!list.Contains(item))
                    list.Add(item);
            }
            RoomSelect = list;
            Student = student;

            if (_index is 0)
                LeftButton.IsEnabled = false;
            else LeftButton.IsEnabled = true;
            if (_index == _context.Студенты.Count() - 1)
                RightButton.IsEnabled = false;
            else RightButton.IsEnabled = true;
        }

        public Students(DormitoriesContext context)
        {
            InitializeComponent();
            Student = new Студенты() { Имя = "dsdad" };

            _context = context;

            SetFields();
        }

        private void RightButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _index++;
            Searchbar.Text = "";
            SetFields();
        }

        private void LeftButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _index--;
            Searchbar.Text = "";
            SetFields();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Searchbar.Text != "")
            {
                foreach (var student in _students)
                    if (student.Фамилия.ToLower().StartsWith(Searchbar.Text.ToLower()))
                    {
                        _index = _students.FindIndex(item => item == student);
                        SetFields();
                        return;
                    }

                Student = new Студенты { Фамилия = "Фамилия", Имя = "Не", Отчетство = "Найдена!" };
            }
            else SetFields();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var firstEntry = _context.Студенты.First();
            var student = new Студенты { Имя = "a", Фамилия = "b", Отчетство = "c"};
            _context.Add(student);
            _context.SaveChanges();
        }
    }
}
