using System.Linq;
using System.Windows.Controls;
using System.Windows;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.Collections;
using System.Windows.Data;
using System.Globalization;

namespace Database.Forms
{
    public class ExtendedComboBoxItemConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, System.Type targetType, object parameter, CultureInfo culture) => value;
        object IValueConverter.ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            var str = value as string;
            if (str is not null and "New...")
                return targetType.IsValueType ? System.Activator.CreateInstance(targetType) : null;
            return value;
        }
    }

    public class ExtendedComboBox : ComboBox
    {
        private static readonly string s_newTrivia = "New...";

        private class ExtendedEnumerable : IEnumerable
        {
            private readonly IEnumerable _enumerable;

            public object NewItem { get; set; }

            public ExtendedEnumerable(IEnumerable enumerable, object newItem) =>
                (_enumerable, NewItem) = (enumerable, newItem);

            public IEnumerator GetEnumerator()
            {
                foreach (var item in _enumerable)
                    yield return item;
                yield return NewItem;
            }
        }

        public event System.EventHandler NewOptionSelected = static delegate { };

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Contains(s_newTrivia))
            {
                if (e.RemovedItems[0] is not null)
                    SelectedItem = e.RemovedItems[0];
                NewOptionSelected(this, System.EventArgs.Empty);
            }

            base.OnSelectionChanged(e);
        }

        protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            if (newValue is ExtendedEnumerable)
                return;

            base.OnItemsSourceChanged(oldValue, newValue);

            var extend = new ExtendedEnumerable(newValue, s_newTrivia);
            ItemsSource = extend;
        }
    }
}
