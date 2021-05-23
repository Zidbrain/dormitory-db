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
    /// Interaction logic for Floors.xaml
    /// </summary>
    public partial class Floors : FormBase<Этажи>
    {
        public Floors() => InitializeComponent();

        protected override Этажи GetNewItem() =>
            new() { ЭтажId = (content.Items[^1] as Этажи).ЭтажId + 1 };

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window { Title = "Комнаты", SizeToContent = SizeToContent.WidthAndHeight, FontSize = 18 };
            var rooms = new Rooms { ItemsList = Item.Комнаты.ToList(), Context = Context };
            (rooms.Content as DataGrid).IsReadOnly = true;
            window.Content = rooms;
            window.ShowDialog();
        }

        private void ContentControl_Remove(object sender, RoutedEventArgs e) =>
            StandartRemove(sender as ContentControl);

        private void content_Add(object sender, RoutedEventArgs e) =>
            StandartAdd(sender as ContentControl);
    }
}
