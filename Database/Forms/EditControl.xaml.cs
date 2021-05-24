using System.Windows;
using System.Windows.Controls;

namespace Database.Forms
{
    /// <summary>
    /// Interaction logic for EditControl.xaml
    /// </summary>
    public partial class EditControl : UserControl
    {
        public static readonly DependencyProperty ContextProperty = DependencyProperty.Register("Context", typeof(DormitoriesContext), typeof(EditControl));
        public DormitoriesContext Context
        {
            get => (DormitoriesContext)GetValue(ContextProperty);
            set => SetValue(ContextProperty, value);
        }
        
        private readonly MainWindow _window;

        public EditControl(MainWindow window)
        {
            InitializeComponent();

            Context = new DormitoriesContext();

            _window = window;

            //(TabControl.Items[0] as TabItem).Content = new Students(_context);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Context.Dispose();
            _window.ContentControl.Content = _window.Menu;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var stud = (TabControl.Items[0] as TabItem).Content as Students;
            if (Validation.GetHasError(stud.Cellphone) || Validation.GetHasError(stud.Passport))
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }    

            Context.SaveChanges();
        }
    }
}
