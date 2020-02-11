using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using EntitiyFramework.Models;

namespace EntitiyFramework
{
    
    public partial class MainWindow : Window
    {
        public EfServiceDb DatabaseService = new EfServiceDb();

        public MainWindow()
        {
            InitializeComponent();
            GetSource();
            
        }

        private void GetSource()
        {
            MyDataGrid.ItemsSource = DatabaseService.GetStudents().ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newStudent = new Student
            {
                FirstName = "Mehmet",
                LastName = "Okur",
                Address = "Utah",
                IndexNumber = "23178",
                IdStudies = 3
            };

            DatabaseService.AddStudent(newStudent);


        }

        private void UpdButton_Click_2(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DelButton_Click_1(object sender, RoutedEventArgs e)
        {
            var std = MyDataGrid.SelectedItem as Student;
            DatabaseService.RemoveStudent(std);
        }
    }
}

