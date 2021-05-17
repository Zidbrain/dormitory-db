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
    /// Interaction logic for StudentsAndGuests.xaml
    /// </summary>
    public partial class StudentsAndGuests : FormBase<Студенты>
    {
        public StudentsAndGuests()
        {
            InitializeComponent();
            Initialize(null, null, leftButton, rightButton, static item => item.Студенты);
        }
    }
}
