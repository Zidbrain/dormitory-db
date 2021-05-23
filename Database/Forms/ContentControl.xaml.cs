using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace Database.Forms
{
    internal class NumItemsConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture) => $" из {{{value}}}";
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }


    internal class TextItemBoxConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture) => (int)value + 1;
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => ((int)value - 1).ToString();
    }

    /// <summary>
    /// Interaction logic for ContentControl.xaml
    /// </summary>
    public partial class ContentControl : UserControl
    {
        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(IList), typeof(ContentControl));
        public IList Items
        {
            get => (IList)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(ContentControl), 
            new PropertyMetadata(static (item, _) => (item as ContentControl).SelectedItemChanged(item, EventArgs.Empty)));
        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        private bool _isReadonly;
        public bool IsReadonly
        {
            get => _isReadonly;
            set
            {
                addButton.IsEnabled = !value;
                removeButton.IsEnabled = !value;
                _isReadonly = value;
            }
        }

        public event EventHandler SelectedItemChanged = static delegate { };

        public static readonly DependencyProperty IndexProperty = DependencyProperty.Register("Index", typeof(int), typeof(ContentControl));
        public int Index
        {
            get => (int)GetValue(IndexProperty);
            set
            {
                if (Items is null)
                {
                    SetValue(IndexProperty, 0);
                    return;
                }

                if (value < 0)
                    value = 0;
                if (value >= Items.Count)
                    value = Items.Count - 1;
                SetValue(IndexProperty, value);
                SelectedItem = Items[Index];
            }
        }

        public ContentControl() => InitializeComponent();

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, @"^\d+$"))
                e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e) => Index--;

        private void Button_Click_1(object sender, RoutedEventArgs e) => Index++;

        private void Button_Click_2(object sender, RoutedEventArgs e) => Index = Items.Count - 1;

        private void Button_Click_3(object sender, RoutedEventArgs e) => Index = 0;

        private void StackPanel_Loaded(object sender, RoutedEventArgs e) => Index = 0;

        public event RoutedEventHandler Add = static delegate { };
        private void Button_Click_4(object sender, RoutedEventArgs e) =>
            Add(this, e);
        public event RoutedEventHandler Remove = static delegate { };

        private void Button_Click_5(object sender, RoutedEventArgs e) => Remove(this, e);
    }
}
