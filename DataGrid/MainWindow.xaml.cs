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

namespace DataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var st = new Student
            {
                IdStudent = 1,
                FirstName = "Anna",
                LastName = "Malewska"
            };

            var st2= new Student
            {
                IdStudent = 2,
                FirstName = "Jan",
                LastName = "Kowalski"
            };

            var list = new List<Student>();
            list.Add(st);
            list.Add(st2);

            StudentDataGrid.ItemsSource = list;
;        }
    }
}
