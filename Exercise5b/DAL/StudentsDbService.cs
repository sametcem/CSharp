using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5b.DAL
{
    public class StudentsDbService
    {
        string ConnectionString = "Data Source=db-mssql;Initial Catalog=s17181;Integrated Security=True";

        public List<Student> DatabaseConnection()
        {
            List<Student> ListOfStudents = new List<Student>();
            using (SqlConnection ConnectionSQL = new SqlConnection(ConnectionString))
            {
                ConnectionSQL.Open();
                using (SqlCommand command = new SqlCommand("SELECT  * FROM APBD.Student", ConnectionSQL))
                using (SqlDataReader ReaderSQL = command.ExecuteReader())
                {
                    while (ReaderSQL.Read())
                    {
                        int IDStudent = ReaderSQL.GetInt32(ReaderSQL.GetOrdinal("IdStudent"));
                        string FirstName = ReaderSQL["FirstName"].ToString();
                        string LastName = ReaderSQL["LastName"].ToString();
                        string Address = ReaderSQL["Address"].ToString();
                        string IndexNumber = ReaderSQL["IndexNumber"].ToString();
                        int IDStudies = ReaderSQL.GetInt32(ReaderSQL.GetOrdinal("IdStudies"));
                        string m = GetListOfStudentStudies(IDStudent);
                        ListOfStudents.Add(new Student(IDStudent, FirstName, LastName, Address, IndexNumber, IDStudies, m));
                    }
                }
            }
            return ListOfStudents;
        }

        public List<Subject> GetListOfSubjects()
        {
            List<Subject> ListOfSubjects = new List<Subject>();
            using (SqlConnection ConnectionSQL = new SqlConnection(ConnectionString))
            {
                ConnectionSQL.Open();
                using (SqlCommand command = new SqlCommand("SELECT  * FROM APBD.Subject", ConnectionSQL))
                using (SqlDataReader ReaderSQL = command.ExecuteReader())
                {
                    while (ReaderSQL.Read())
                    {
                        int IDSubject = ReaderSQL.GetInt32(ReaderSQL.GetOrdinal("IdSubject"));
                        string Name = ReaderSQL["Name"].ToString();
                        ListOfSubjects.Add(new Subject(IDSubject, Name));
                    }
                }
            }
            return ListOfSubjects;
        }

        public List<Studies> GetListOfStudies()
        {
            List<Studies> ListOfStudies = new List<Studies>();
            using (SqlConnection ConnectionSQL = new SqlConnection(ConnectionString))
            {
                ConnectionSQL.Open();
                using (SqlCommand command = new SqlCommand("SELECT  * FROM APBD.Studies", ConnectionSQL))
                using (SqlDataReader ReaderSQL = command.ExecuteReader())
                {
                    while (ReaderSQL.Read())
                    {
                        int IDStudy = ReaderSQL.GetInt32(ReaderSQL.GetOrdinal("IdStudies"));
                        string Name = ReaderSQL["Name"].ToString();
                        ListOfStudies.Add(new Studies(IDStudy, Name));
                    }
                }
            }
            return ListOfStudies;
        }

        public string GetListOfStudentStudies(int StudentID)
        {
            string StudentStudies = "";
            using (SqlConnection ConnectionSQL = new SqlConnection(ConnectionString))
            {
                ConnectionSQL.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM APBD.Student INNER JOIN APBD.Studies ON Studies.IdStudies = Student.IdStudies WHERE IdStudent = '" + StudentID + "'", ConnectionSQL))
                using (SqlDataReader ReaderSQL = command.ExecuteReader())
                {
                    while (ReaderSQL.Read())
                    {
                        string Name = ReaderSQL["Name"].ToString();
                        StudentStudies = Name;
                    }
                }
            }
            return StudentStudies;
        }

        public List<Subject> GetListOfStudentSubjects(int StudentID)
        {
            List<Subject> ListOfStudentSubject = new List<Subject>();
            using (SqlConnection ConnectionSQL = new SqlConnection(ConnectionString))
            {
                ConnectionSQL.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM APBD.Student_Subject INNER JOIN APBD.Subject ON Subject.IdSubject = Student_Subject.IdSubject " +
                    "INNER JOIN APBD.Student ON Student.IdStudent = Student_Subject.IdStudent WHERE Student.IdStudent = '" + StudentID + "'", ConnectionSQL))
                using (SqlDataReader ReaderSQL = command.ExecuteReader())
                {
                    while (ReaderSQL.Read())
                    {
                        int IDSubject = ReaderSQL.GetInt32(ReaderSQL.GetOrdinal("IdSubject"));
                        string Name = ReaderSQL["Name"].ToString();
                        ListOfStudentSubject.Add(new Subject(IDSubject, Name));
                    }
                }
            }
            return ListOfStudentSubject;
        }

        public void UpdateStudent(int StudentID, string FirstName, string LastName, string Address, string IndexNumber, int IDStudiesName)
        {
            using (SqlConnection ConnectionSQL = new SqlConnection(ConnectionString))
            {
                ConnectionSQL.Open();
                using (SqlCommand command = new SqlCommand("UPDATE APBD.Student SET FirstName = @FirstName, LastName = @LastName, Address = @Address, IndexNumber = @IndexNumber, IdStudies = @IDStudies WHERE IdStudent = " + StudentID, ConnectionSQL))
                {
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@IndexNumber", IndexNumber);
                    command.Parameters.AddWithValue("@IdStudies", IDStudiesName);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }

        public void RemoveStudentID(int StudentID)
        {
            using (SqlConnection ConnectionSQL = new SqlConnection(ConnectionString))
            {
                ConnectionSQL.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM APBD.Student WHERE IdStudent = " + StudentID, ConnectionSQL))
                using (SqlDataReader reader = command.ExecuteReader())
                    ConnectionSQL.Close();
            }
        }


        public void AddStudent(string FirstName, string LastName, string IndexNumber, string Address, int IdStudies)
        {
            using (SqlConnection ConnectionSQL = new SqlConnection(ConnectionString))
            {
                ConnectionSQL.Open();
               
                using (SqlCommand command = new SqlCommand("INSERT INTO APBD.Student (FirstName, LastName, Address, IndexNumber, IdStudies) VALUES (@FirstName, @LastName, @Address, @IndexNumber, @IDStudies)", ConnectionSQL))
                {
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@IndexNumber", IndexNumber);
                    command.Parameters.AddWithValue("@IdStudies", IdStudies);

                    int affectedRows = command.ExecuteNonQuery();
                }
                
                ConnectionSQL.Close();

            }
        }

        /*
        public void QueryParameters()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM Tabela WHERE Id=@Id", con))
                {
                    command.Parameters.AddWithValue("@Id", 10);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }
        */

        //public void TransactionUse()
        //{
        //    string ConnectionString = "Data Source=db-mssql;Initial Catalog=s16983;Integrated Security=True";
        //    using (SqlConnection ConnectionSQL = new SqlConnection(ConnectionString))
        //    {
        //        ConnectionSQL.Open();
        //        var tran = ConnectionSQL.BeginTransaction();

        //        using (SqlCommand command = new SqlCommand("DELETE FROM Tabela WHERE Id=@Id", tran))
        //        {
        //            command.Parameters.AddWithValue("@Id", 10);
        //            int affectedRows = command.ExecuteNonQuery();
        //        }

        //        //....

        //        tran.Commit();
        //    }
        //}


    }

}
