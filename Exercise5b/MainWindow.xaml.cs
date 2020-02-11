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
using Exercise5b.DAL;

namespace Exercise5b
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Student> ListOfStudents;
        private StudentsDbService DatabaseStudentController;

        public MainWindow()
        {
            InitializeComponent();
            DatabaseStudentController = new StudentsDbService();
            ListOfStudents = new ObservableCollection<Student>();
            List<Student> ListOfStudentsDatabase = DatabaseStudentController.DatabaseConnection();
            StudentsListGrid.ItemsSource = ListOfStudentsDatabase;
            DeleteStudentButton.Click += DeleteStudentButtonOnClick;
        }

      

        private void AddEditStudentButtonOnClick(object sender, RoutedEventArgs e)
        {
            AddEditStudent AddStudentWindow = new AddEditStudent(DatabaseStudentController, "Add");
            AddStudentWindow.Show();
            this.Close();
        }

        private void DeleteStudentButtonOnClick(object sender, RoutedEventArgs e)
        {   //For multiple selection and deletion.
            List<Student> ListOfStudentsDeleteSelection = StudentsListGrid.SelectedItems.Cast<Student>().ToList();
            DeleteStudentConfirmation ConformationWindow = new DeleteStudentConfirmation(DatabaseStudentController, ListOfStudentsDeleteSelection);
            ConformationWindow.Show();
            this.Close();
        }

        private void StudentsListGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (StudentsListGrid.SelectedItem != null)
            {
                Student EditSelectedStudent = (Student)StudentsListGrid.SelectedItem;
                AddEditStudent AddStudentWindow = new AddEditStudent(DatabaseStudentController, "Edit", EditSelectedStudent);
                AddStudentWindow.Show();
                this.Close();
            }
        }

        private void StudentsListGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = StudentsListGrid.SelectedItems;
            int count = 0;
            foreach (var item in selected)
            {
                var student = item as StudentsDbService;
                count++;
            }

            LabelCounter.Content = count;
        }

    }
}
