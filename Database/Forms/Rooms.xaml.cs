using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;

namespace Database.Forms
{
    public class DbSetConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is "true")
            {
                if (value is DbSet<Студенты> studs)
                    return studs.Select(static item => item.СтудентId).ToList();
                else if (value is DbSet<Комнаты> rooms)
                    return rooms.Select(static item => item.НомерКомнаты).OrderBy(static item => item).ToList();
            }

            return Enumerable.ToList(value as dynamic);
            //if ((Type)parameter == typeof(Студенты))//    return (value as DbSet<Студенты>).Select(static item => item.СтудентId).ToList();//else if ((Type)parameter == typeof(Комнаты))//    return (value as DbSet<Комнаты>).ToList();//else if ((Type)parameter == typeof(Гости))//    return (value as DbSet<Гости>).ToList();//else if ((Type)parameter == typeof(КоличествоСтудентовПоКомнатам))//    return (value as DbSet<КоличествоСтудентовПоКомнатам>).ToList();//else if ((Type)parameter == typeof(НеОплатившиеПроживания))//    return (value as DbSet<НеОплатившиеПроживания>).ToList();//else if ((Type)parameter == typeof(НеВыполнившиеДежурства))//    return (value as DbSet<НеВыполнившиеДежурства>).ToList();//return value;
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
        public Rooms() => InitializeComponent();
    }
}
