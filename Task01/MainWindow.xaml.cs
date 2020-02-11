using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
using Task01.Models;

namespace Task01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TreeViewItem students = new TreeViewItem { Header="Students"};
            

            TreeViewItem stationary = new TreeViewItem { Header = "Stationary" };
            TreeViewItem Informatyka = new TreeViewItem {Header = "Informatyka" };
            TreeViewItem Grafika = new TreeViewItem { Header = "Grafika" };

            stationary.Items.Add(Informatyka);
            stationary.Items.Add(Grafika);
            students.Items.Add(stationary);

            TreeViewItem zaoczne = new TreeViewItem { Header = "Zaoczne" };
            TreeViewItem internotowe = new TreeViewItem { Header = "Internotowe" };

            students.Items.Add(zaoczne);
            students.Items.Add(internotowe);

            PersonTypeTreeView.Items.Add(students);

            TreeViewItem pracownicy = new TreeViewItem { Header = "Pracownicy" };

            TreeViewItem dydaktycy = new TreeViewItem { Header = "Dydaktycy" };
            TreeViewItem administracja = new TreeViewItem { Header = "Administracja" };

            pracownicy.Items.Add(dydaktycy);
            pracownicy.Items.Add(administracja);

            PersonTypeTreeView.Items.Add(pracownicy);


            var std = new Student { IDStudent = 1, FirstName = "Jan", LastName = "Kowalski", NrIndeksu = "s00010", Status = "Student", rok = 2019, Semester = "2018/2019 letni", Specialisation = "Bazy danych", uwagi = "Brak" };
            var std2 = new Student
            {
                IDStudent = 2,
                FirstName = "Marius",
                LastName = "Zalewski",
                NrIndeksu = "s00011",
                Status = "Student",
                rok = 2019,
                Semester = "2018/2019 letni",
                Specialisation = "Bazy danych",
                uwagi = "Brak"

            };

            var std3 = new Student { IDStudent = 3, FirstName = "John", LastName = "Mayer",NrIndeksu = "s00001",Status = "Student",rok = 2019,Semester ="2018/2019 letni",Specialisation = "Bazy danych",uwagi = "Brak"};
            var std4 = new Student { IDStudent = 4, FirstName = "Marek", LastName = "Kowalski", NrIndeksu = "s00002", Status = "Student", rok = 2019, Semester = "2018/2019 letni", Specialisation = "Bazy danych", uwagi = "Brak" };
            var std5 = new Student { IDStudent = 5, FirstName = "Paul", LastName = "Johnson", NrIndeksu = "s00003", Status = "Student", rok = 2019, Semester = "2018/2019 letni", Specialisation = "Bazy danych", uwagi = "Brak" };
            var std6 = new Student { IDStudent = 6, FirstName = "James", LastName = "White", NrIndeksu = "s00004", Status = "Student", rok = 2019, Semester = "2018/2019 letni", Specialisation = "Bazy danych", uwagi = "Brak" };
            var std7 = new Student { IDStudent = 7, FirstName = "Eric", LastName = "Cramer", NrIndeksu = "s00005", Status = "Student", rok = 2019, Semester = "2018/2019 letni", Specialisation = "Bazy danych", uwagi = "Brak" };
            var std8 = new Student { IDStudent = 8, FirstName = "Frank", LastName = "Vedder", NrIndeksu = "s00006", Status = "Student", rok = 2019, Semester = "2018/2019 letni", Specialisation = "Bazy danych", uwagi = "Brak" };

            var list = new List<Student>();
            list.Add(std);
            list.Add(std2);
            list.Add(std3);
            list.Add(std4);
            list.Add(std5);
            list.Add(std6);
            list.Add(std7);
            list.Add(std8);

            StudentsDataGrid.ItemsSource = list;
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
