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
    public partial class DeleteStudentConfirmation : Window
    {
        private StudentsDbService DatabaseStudentController1;
        List<Student> ListOfStudentsDeleteSelection1;

        public DeleteStudentConfirmation(StudentsDbService DatabaseStudentController, List<Student> ListOfStudentsDeleteSelection)
        {
            ListOfStudentsDeleteSelection1 = ListOfStudentsDeleteSelection;
            InitializeComponent();
            DatabaseStudentController1 = DatabaseStudentController;
            YESButton.Click += ConfirmDeleteStudentYES;
            NOButton.Click += ConfirmDeleteStudentNO;
        }

        private void ConfirmDeleteStudentYES(object sender, RoutedEventArgs e)
        {
            foreach (var a in ListOfStudentsDeleteSelection1)
                DatabaseStudentController1.RemoveStudentID(a.IDStudent);
           
            new MainWindow().Show();
            this.Close();
        }

        private void ConfirmDeleteStudentNO(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}
