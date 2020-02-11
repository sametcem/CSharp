using RetakeTest.Models;
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
using System.Data.Entity;

namespace RetakeTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EDbCon db;
        public List<EMP> Emps { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            db = new EDbCon();
            getSource();
        }

        public void getSource()
        {
            var result = db.EMPs.Include(e => e.DEPT).ToList();
            EmpDataGrid.ItemsSource = result;

        }

        private void addClick(object sender, RoutedEventArgs e)
        {
            int maxID = 0;
            db.EMPs.ToList().ForEach(p =>
            {
                if (p.EMPNO > maxID)
                {
                    maxID = p.EMPNO;
                }
            });

           int newID = maxID + 1;

            var newEmp = new EMP
            {
                EMPNO = newID,
                ENAME = FirstNameTextBox.Text,
                JOB = JobTextBox.Text,
                DEPTNO = 10,
                SAL = 1000
            };

           AddEmp(newEmp);
           
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var emp = (EMP)EmpDataGrid.SelectedItem;
            db.EMPs.Remove(db.EMPs.ToList().First(p => p.EMPNO == emp.EMPNO));
            db.SaveChanges();
            getSource();
        }

        private void EmpDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int count = EmpDataGrid.SelectedItems.Count;
            studentCount.Content = "You choosed " + count + " Employees";
        }

        public void AddEmp(EMP emp)
        {
            db.EMPs.Add(emp);
            db.SaveChanges();
            getSource();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var empname = SearchTextBox.Text;

            var result = db.EMPs.Where(emp => emp.ENAME == empname).ToList();
            EmpDataGrid.ItemsSource = result;

            

        }

        private void SearchAllButton_Click(object sender, RoutedEventArgs e)
        {
            getSource();
        }
    }
}
