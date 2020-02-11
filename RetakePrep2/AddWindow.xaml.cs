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
using System.Windows.Shapes;
using RetakePrep2.Models;

namespace RetakePrep2
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        MainWindow _mainWindow;
        private int newID;

        public AddWindow()
        {
            InitializeComponent();
        }

        public AddWindow(List<DEPT> depts, MainWindow main, int maxID)
        {
            InitializeComponent();
            DeptComboBox.ItemsSource = depts;
            _mainWindow = main;
            newID = maxID + 1; 

        }

        private void Save_Button_OnClick_Button_Click(object sender, RoutedEventArgs e)
        {
            var newEmp = new EMP
            {
                EMPNO = newID,
                ENAME = FirstNameTextBox.Text,
                JOB = JobTextBox.Text,
                DEPTNO = ((DEPT)DeptComboBox.SelectedItem).DEPTNO
            };

            _mainWindow.AddEmp(newEmp);
            Close();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
