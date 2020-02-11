using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LastApps.Models;

namespace LastApps
{
    public partial class AddEditWindow : Window
    {
        private MainWindow main;
        private Student student;
        ObservableCollection<Study> chosenStudies = new ObservableCollection<Study>();
        ObservableCollection<Subject> chosenSubjects = new ObservableCollection<Subject>();

        // For adding
        public AddEditWindow(MainWindow main, ObservableCollection<Study> studies, ObservableCollection<Subject> subjects)
        {
            InitializeComponent();
            this.main = main;
            EditAddStudentLabel.Text = "Adding";
            ComboBoxStudy.ItemsSource = studies;
            ListBoxSubject.ItemsSource = subjects;
        }

        // For editing
        public AddEditWindow(MainWindow main, ObservableCollection<Study> studies, ObservableCollection<Subject> subjects, Student student)
        {
            InitializeComponent();
            this.main = main;
            EditAddStudentLabel.Text = "Editing";

            TextBoxFirstName.Text = student.Name;
            TextBoxLastName.Text = student.Surname;
            TextBoxAddress.Text = student.Address;
            TextBoxIndex.Text = student.IndexNumber;
            ComboBoxStudy.ItemsSource = studies;
            ListBoxSubject.ItemsSource = subjects;

            this.student = student;
        }


        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OKButtonClick(object sender, RoutedEventArgs e)
        {
            List<Subject> sub = new List<Subject>();
            string index = TextBoxIndex.Text;

            if (Regex.IsMatch(index, @"^(s\d+)$"))
            {
                if (ComboBoxStudy.SelectedItem == null || ListBoxSubject.SelectedItem == null)
                {
                    MessageBox.Show("Error. choose a study and a subject");
                    return;
                }

                foreach (var subject in ListBoxSubject.SelectedItems)
                {
                    sub.Add((Subject)subject);
                }

                if (EditAddStudentLabel.Text == "Adding")
                {
                    var newStudent = new Student
                    {
                        Surname = TextBoxLastName.Text,
                        Name = TextBoxFirstName.Text,
                        Address = TextBoxAddress.Text,
                        IndexNumber = TextBoxIndex.Text,
                        Study = (Study)ComboBoxStudy.SelectedItem,
                        Subject = sub
                    };
                    main.Insert(newStudent);
                    Close();
                }
                else if (EditAddStudentLabel.Text == "Editing")
                {
                    student.Name = TextBoxFirstName.Text;
                    student.Surname = TextBoxLastName.Text;
                    student.Address = TextBoxAddress.Text;
                    student.IndexNumber = TextBoxIndex.Text;
                    student.Study = (Study)ComboBoxStudy.SelectedItem;
                    student.Subject = sub;
                    main.Update(student, student.IdStudent);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Error. index should be starts with S then number");
            }
        }
    }

}
