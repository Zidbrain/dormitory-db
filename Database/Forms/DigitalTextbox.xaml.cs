using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace Database.Forms
{
    /// <summary>
    /// Interaction logic for DigitalTextbox.xaml
    /// </summary>
    public partial class DigitalTextbox : UserControl
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int?), typeof(DigitalTextbox));
        public int? Value
        {
            get => (int?)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public IEnumerable<int> ExcludeValues { get; set; }

        public DigitalTextbox() => InitializeComponent();

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, @"^\d+$"))
                e.Handled = true;
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            if (Value is null)
                Value = 0;
            else Value++;
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            if (Value is null)
                Value = 0;
            else Value--;
        }
    }
}
