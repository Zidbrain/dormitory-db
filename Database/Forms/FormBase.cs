using System.Linq;
using System.Windows.Controls;
using System.Windows;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Database.Forms
{
    public class FormBase<T> : UserControl where T : class, new()
    {
        private System.Func<DormitoriesContext, DbSet<T>> _getSet;

        protected int Index { get; set; }
        protected DormitoriesContext Context { get; set; }
        protected List<T> Items { get; set; }

        private Button _leftButton, _rightButton;

        public void Save() => Context.SaveChanges();

        public static readonly DependencyProperty ItemProperty = DependencyProperty.Register("Item", typeof(T), typeof(FormBase<T>));
        public T Item
        {
            get => (T)GetValue(ItemProperty);
            set => SetValue(ItemProperty, value);
        }

        protected void Initialize(Button addButton, Button removeButton, Button leftButton, Button rightButton, DormitoriesContext context, System.Func<DormitoriesContext, DbSet<T>> getDbSet)
        {
            (_leftButton, _rightButton, Context, _getSet) = (leftButton, rightButton, context, getDbSet);

            if (_leftButton is not null)
                _leftButton.Click += LeftButtonClick;
            if (_rightButton is not null)
                _rightButton.Click += RightButtonClick;

            if (addButton is not null)
                addButton.Click += AddButtonClick;
            if (removeButton is not null)
                removeButton.Click += RemoveButtonClick;

            SetFields();
        }

        protected virtual void SetFields()
        {
            if (Context is null)
                return;

            Items = _getSet(Context).ToList();
            var item = Items.ElementAt(Index);
            Item = item;

            if (_leftButton is not null)
                if (Index is 0)
                    _leftButton.IsEnabled = false;
                else _leftButton.IsEnabled = true;
            if (_rightButton is not null)
                if (Index == Items.Count - 1)
                    _rightButton.IsEnabled = false;
                else _rightButton.IsEnabled = true;
        }

        protected virtual void LeftButtonClick(object sender, RoutedEventArgs e)
        {
            Index--;
            SetFields();
        }

        protected virtual void RightButtonClick(object sender, RoutedEventArgs e)
        {
            Index++;
            SetFields();
        }

        protected virtual void AddButtonClick(object sender, RoutedEventArgs e)
        {
            var item = new T();
            Context.Add(item);
            Context.SaveChanges();

            Items = _getSet(Context).ToList();
            Index = Items.Count - 1;
            Item = Items[Index];
            SetFields();
        }

        protected virtual void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            Context.Remove(Item);
            Context.SaveChanges();

            Items = _getSet(Context).ToList();
            if (Index >= Items.Count)
                Index = Items.Count - 1;

            Item = Items[Index];
            SetFields();
        }
    }
}
