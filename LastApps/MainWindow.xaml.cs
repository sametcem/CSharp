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
using LastApps.DAL;
using LastApps.Models;

namespace LastApps
{
    public partial class MainWindow : Window
    {
        private StudentsDbService Dbsconfig = new StudentsDbService();

        public ObservableCollection<Student> students;
        public ObservableCollection<Study> studies;
        public ObservableCollection<Subject> subjects;

        public MainWindow()
        {
            InitializeComponent();
            loadGridData();
        }

        private void loadGridData()
        {
            students = Dbsconfig.getStudents();
            StudentsDataGrid.ItemsSource = students;
        }

        private void Add_Button_OnClick(object sender, RoutedEventArgs e)
        {
            studies = Dbsconfig.getStudies();
            subjects = Dbsconfig.getSubjects();
            var addWindow = new AddEditWindow(this, studies, subjects);
            addWindow.ShowDialog();

        }

        private void Delete_Button_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult boxResult = MessageBox.Show("Are you sure want to delete the student data?", "Confirmation", MessageBoxButton.YesNo);
            switch (boxResult)
            {
                case MessageBoxResult.Yes:
                    foreach (Student s in StudentsDataGrid.SelectedItems)
                    {
                        Dbsconfig.deleteStudent(s.IdStudent);
                    }
                    loadGridData();
                    break;
                case MessageBoxResult.No:
                    break;
            }

        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (StudentsDataGrid.SelectedIndex > -1)
            {
                studies = Dbsconfig.getStudies();
                subjects = Dbsconfig.getSubjects();
                var addWindow = new AddEditWindow(this, studies, subjects, (Student)StudentsDataGrid.SelectedItem);
                addWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error. choose a student");
            }

        }
        public void Insert(Student student)
        {
            Dbsconfig.AddStudent(student);
            loadGridData();
        }

        public void Update(Student student, int id)
        {
            Dbsconfig.UpdateStudent(student, id);
            loadGridData();
        }
        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int count = StudentsDataGrid.SelectedItems.Count;
            studentCount.Content = "You choosed " + count + " students";
        }
    }
}
