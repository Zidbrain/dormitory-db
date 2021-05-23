using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Database
{
    /// <summary>
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : UserControl
    {
        public static readonly DependencyProperty ContextProperty = DependencyProperty.Register("Context", typeof(DormitoriesContext), typeof(Reports));
        public DormitoriesContext Context
        {
            get => (DormitoriesContext)GetValue(ContextProperty);
            set => SetValue(ContextProperty, value);
        }

        private readonly MainWindow _mainWindow;

        public Reports(MainWindow mainWindow)
        {
            InitializeComponent();
            Context = new DormitoriesContext();
            _mainWindow = mainWindow;
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var sum = 0m;
            foreach (НеОплатившиеПроживания item in (sender as DataGrid).Items)
                sum += Context.Студенты.Find(item.СтудентId).Проживания.ПлатаЗаМесяц ?? 0m;
            PaySum.Text = sum.ToString();
        }

        private void DataGrid_Loaded_1(object sender, RoutedEventArgs e)
        {
            var sum = 0;
            foreach (НеВыполнившиеДежурства item in (sender as DataGrid).Items)
                sum++;
            DutiesSum.Text = sum.ToString();
        }

        private async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using var context = new DormitoriesContext();
            dataGrid.ItemsSource = await context.Procedures.ВремяпроживанияAsync((int?)e.AddedItems[0]);
        }

        private async void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            using var context = new DormitoriesContext();
            dutiesGrid.ItemsSource = await context.Procedures.ДежурстваподатеAsync((DateTime)e.AddedItems[0]);
        }

        private void DutiesGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Выполнено")
                e.Column = new DataGridCheckBoxColumn { Header = "Выполнено", Binding = new Binding("Выполнено") };
        }

        private async void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            using var context = new DormitoriesContext();
            roomsGrid.ItemsSource = await context.Procedures.КоличествостудентоввкомнатеAsync((int)e.AddedItems[0]);
        }

        private async void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            using var context = new DormitoriesContext();
            guests.ItemsSource = await context.Procedures.ПосещениегостямиAsync((int)e.AddedItems[0]);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var control = ((tabControl.SelectedItem as ContentControl).Content as StackPanel).Children[0] as ItemsControl;
            (control.Template.FindName("time", control) as TextBlock).Text = DateTime.Now.ToString(System.Globalization.CultureInfo.CurrentCulture);

            var dialog = new PrintDialog();
            if (dialog.ShowDialog() is true)
                dialog.PrintVisual(tabControl.SelectedContent as Visual, $"Отчёт: {(tabControl.SelectedItem as TabItem).Header}");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) => _mainWindow.ContentControl.Content = _mainWindow.Menu;
    }
}
