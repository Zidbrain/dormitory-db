﻿using System;
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
    /// Interaction logic for Duties.xaml
    /// </summary>
    public partial class Duties : FormBase<Дежурства>
    {
        public Duties()
        {
            InitializeComponent();
        }

        private void ContentControl_Remove(object sender, RoutedEventArgs e) =>
            StandartRemove(sender as ContentControl);

        private void ContentControl_Add(object sender, RoutedEventArgs e) =>
            StandartAdd(sender as ContentControl);

    }
}
