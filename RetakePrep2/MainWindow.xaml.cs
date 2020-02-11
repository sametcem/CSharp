using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using RetakePrep2;
using RetakePrep2.Models;

namespace RetakePrep2
{
    public partial class MainWindow : Window
    {
        EDbCont db;
        public MainWindow()
        {
            InitializeComponent();
            db = new EDbCont();
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
            Window a1 = new AddWindow(db.DEPTs.ToList(), this, maxID);
            a1.Show();
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
    }
}
