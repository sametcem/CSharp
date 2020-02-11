using Exercise4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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

namespace Exercise4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Student> students = new ObservableCollection<Student>(); // define as the class level variable // refresh it observable collection
        public MainWindow()
        {
            InitializeComponent();

            //LoadDataWithItemsCollection();
            LoadDataWithItemsSource();
        }

        private void LoadDataWithItemsSource()
        {
            //OleDbConnection, OleDbCommand
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s17181;Integrated Security=True"))
            {
                var com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "select * from AEMP";

                //Run
                con.Open(); //!
                SqlDataReader dr = com.ExecuteReader();
                //dr.Size() bilinmiyor o yüzden while loop kullanıyoruz
                while (dr.Read())
                {
                    string name = dr["ename"].ToString();
                    string job = dr["job"].ToString();

                    students.Add(new Student
                    {
                        FirstName = name,
                        LastName = job,
                        Gender = true
                    });
                }
            }
            //con.Dispose(); // will be automatically done.
            // IDisposable -> Dispose

            students.Add(new Student
            {
                IdStudent = 1,
                FirstName = "Jan",
                LastName = "Kowalski"
            });

            StudentsListBox.ItemsSource = students;
            StudentsDataGrid.ItemsSource = students;
        }

        private void LoadDataWithItemsCollection()
        {
            // Same operation with <ListBoxItem> Kwiatkowski </ListBoxItem>
            //Control can display different types of data.(Run and see what "toString" method does.
            StudentsListBox.Items.Add(new ListBoxItem {Content = "Kwiatkowski"});
            StudentsListBox.Items.Add("Malewski");
            StudentsListBox.Items.Add(new Student
            {
                IdStudent = 1,
                FirstName = "Andrzej",
                LastName = "Andrzejewski"
            });
        }

        private void ShowSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            //var st = (Student) StudentsListBox.SelectedItem; -> Casting
            MessageBox.Show(StudentsListBox.SelectedItem.ToString());

        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            students.Add(new Student
            {
                IdStudent = 2,
                FirstName = "Andrzej",
                LastName = "Malewski",
                Gender = true
            });

            //To force the control refresh but Dirty way
            //StudentsListBox.ItemsSource = null;
            //StudentsListBox.ItemsSource = students;

        }
    }
}

