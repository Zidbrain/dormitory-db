using System.Linq;
using System.Windows.Controls;
using System.Windows;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Windows.Data;

namespace Database.Forms
{
    public class FormBase<T> : UserControl where T : class, new()
    {
        public static readonly DependencyProperty ContextProperty = DependencyProperty.Register("Context", typeof(DormitoriesContext), typeof(FormBase<T>), new PropertyMetadata((item, e) =>
            (item as FormBase<T>).OnContextChanged(e.OldValue as DormitoriesContext, e.NewValue as DormitoriesContext)));

        protected virtual void OnContextChanged(DormitoriesContext old, DormitoriesContext @new) { }

        public DormitoriesContext Context
        {
            get => (DormitoriesContext)GetValue(ContextProperty);
            set => SetValue(ContextProperty, value);
        }

        public static readonly DependencyProperty ItemProperty = DependencyProperty.Register("Item", typeof(T), typeof(FormBase<T>));
        public T Item
        {
            get => (T)GetValue(ItemProperty);
            set => SetValue(ItemProperty, value);
        }

        protected virtual T GetNewItem() => new();

        protected void StandartAdd(ContentControl control)
        {
            Context.Add(GetNewItem());
            Context.SaveChanges();

            control.GetBindingExpression(ContentControl.ItemsProperty).UpdateTarget();
            control.Index = control.Items.Count - 1;
        }

        protected void StandartRemove(ContentControl control)
        {
            Context.Remove(Item);
            Context.SaveChanges();

            control.GetBindingExpression(ContentControl.ItemsProperty).UpdateTarget();
            if (control.Index >= control.Items.Count)
                control.Index = control.Items.Count - 1;
        }

        public FormBase() { }
    }
}
