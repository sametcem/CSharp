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
using Ex7_Last.Models;

namespace Ex7_Last
{
  
    public partial class MainWindow : Window
    {
        StudentDbCon db;

        public MainWindow()
        {
            InitializeComponent();
            db = new StudentDbCon();
            getSource();

        }

        public void getSource()
        {
            var result = db.Students.Include(s => s.Study).ToList(); //including study
            StudentListDataGrid.ItemsSource = result;
        }

        public void AddNewStudent(Student student, List<Subject> subjects)
        {
            db.Students.Add(student);
            db.SaveChanges();

            var stId = db.Students.ToList().Last(); // pick the last added
            subjects.ForEach(s => db.Student_Subject.Add(new Student_Subject // adding his subject
            {
                IdStudent = stId.IdStudent,
                IdSubject = s.IdSubject,
                CreatedAt = DateTime.Now
            }));
            db.SaveChanges();
            getSource();
        }

        // version 0 is adding.
        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var Edit_Dialog = new Window1(this, db.Studies.ToList(), 0, db.Subjects.ToList());
            Edit_Dialog.Show();
        }

        public void UpdateStudent(Student student, List<Subject> subjects)
        {
            //Returns the only element of a sequence, or a default value if the sequence is empty
            var st = db.Students.SingleOrDefault(s => s.IdStudent == student.IdStudent);
            var ss = db.Student_Subject.Where(s => s.IdStudent == st.IdStudent).ToList();
            subjects.ForEach(s =>
            {
                Boolean exists = false;
                ss.ForEach(p =>
                {
                    if (s.IdSubject == p.IdSubject)
                    {
                        exists = true;
                    }
                    var Old_subjects = subjects.Where(e => e.IdSubject == p.IdSubject)
                        .FirstOrDefault();
                    if (Old_subjects == null)
                    {
                        db.Student_Subject.Remove(p);
                        
                    }
                });
                if (!exists)
                {
                    db.Student_Subject.Add(new Student_Subject
                    {
                        IdStudent = st.IdStudent,
                        IdSubject = s.IdSubject,
                        CreatedAt = DateTime.Now
                    });
                }
            });
            if (st != null)
            {
                st.FirstName = student.FirstName;
                st.LastName = student.LastName;
                st.Address = student.Address;
                st.IndexNumber = student.IndexNumber;
                st.IdStudies = student.IdStudies;
            }
            //db.Student_Subject.Where(ss => ss.IdStudent == student.IdStudent)
            db.SaveChanges();
            getSource();

        }
        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var student = (Student)StudentListDataGrid.SelectedItem;
            db.Students.Remove(db.Students.ToList().First(p => p.IdStudent == student.IdStudent));
            db.SaveChanges();
            getSource();
        }

        //version1 is updating
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var student = (Student)StudentListDataGrid.SelectedItem;
            var MessageBox = new Window1(student, this, db.Studies.ToList(), 1, db.Student_Subject.Where(s => s.IdStudent == student.IdStudent).ToList(), db.Subjects.ToList());
            MessageBox.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           Close();
        }
        // Dynamic label
        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int count = StudentListDataGrid.SelectedItems.Count;
            studentCount.Content = "You choosed " + count + " students";
        }
    }
}
