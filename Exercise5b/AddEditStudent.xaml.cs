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
using Exercise5b.DAL;

namespace Exercise5b
{
    public partial class AddEditStudent : Window
    {
        StudentsDbService dBControler;
        List<Subject> ListOfSubjectsDatabase;
        List<Studies> ListOfStudiesDatabase;
        private Student editSelectedStudent;
        string WindowDecisionNameGLOBAL;

        // Adding the Student
        public AddEditStudent(StudentsDbService dbConnection1, string WindowDecisionName)
        {
            dBControler = dbConnection1;
            InitializeComponent();
            ListOfSubjectsDatabase = dBControler.GetListOfSubjects();
            ListOfStudiesDatabase = dBControler.GetListOfStudies();
            List<string> ListOfSubjectsText = ListOfSubjectsDatabase.Select(s => (string)s.Name).ToList();
            List<string> ListOfStudiesText = ListOfStudiesDatabase.Select(s => (string)s.Name).ToList();
            ListOfSubjectsListBox.ItemsSource = ListOfSubjectsText;
            ListOfStudiesComboBox.ItemsSource = ListOfStudiesText;
            EditAddStudentTextBlock.Text = WindowDecisionName;
            WindowDecisionNameGLOBAL = WindowDecisionName;
        }

        // Editing The Student
        public AddEditStudent(StudentsDbService dbConnection1, string WindowDecisionName, Student editSelectedStudent)
        {
            InitializeComponent();
            this.editSelectedStudent = editSelectedStudent;
            EditAddStudentTextBlock.Text = WindowDecisionName;
            WindowDecisionNameGLOBAL = WindowDecisionName;
            dBControler = dbConnection1;
            FirstNameTextBox.Text = editSelectedStudent.FirstName;
            LastNameTextBox.Text = editSelectedStudent.LastName;
            IndexNumberTextBox.Text = editSelectedStudent.IndexNumber;
            List<string> ListOfSubjectsText = dBControler.GetListOfStudentSubjects(editSelectedStudent.IDStudent).Select(s => (string)s.Name).ToList();
            ListOfStudiesDatabase = dBControler.GetListOfStudies();
            List<string> ListOfStudiesText = ListOfStudiesDatabase.Select(s => (string)s.Name).ToList();
            ListOfSubjectsListBox.ItemsSource = ListOfSubjectsText;
            ListOfStudiesComboBox.ItemsSource = ListOfStudiesText;
            ListOfStudiesComboBox.SelectedItem = editSelectedStudent.StudentsStudies;

        }

        private void ButtonClickSendAdd(object sender, RoutedEventArgs e)
        {
            List<Studies> finder = dBControler.GetListOfStudies();
            string s = (string)ListOfStudiesComboBox.SelectedItem;
            int index = finder.FindIndex(Studies => Studies.Name == s);
            int b = finder.ElementAt(index).ID;

            if (WindowDecisionNameGLOBAL == "Add")
                dBControler.AddStudent(FirstNameTextBox.Text, LastNameTextBox.Text, IndexNumberTextBox.Text, ListOfSubjectsListBox.SelectedValue.ToString(), b);

            if (WindowDecisionNameGLOBAL == "Edit")
                dBControler.UpdateStudent(editSelectedStudent.IDStudent, FirstNameTextBox.Text, LastNameTextBox.Text, IndexNumberTextBox.Text, ListOfSubjectsListBox.SelectedValue.ToString(), b);

            new MainWindow().Show();
            this.Close();
        }

        private void ButtonClickCancel(object sender, RoutedEventArgs e)
        {
            
            new MainWindow().Show();
            this.Close();

        }
    }

}
