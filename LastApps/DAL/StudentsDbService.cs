using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LastApps.Models;

namespace LastApps.DAL
{
    public class StudentsDbService
    {
        private string connectionString = "Data Source=db-mssql;Initial Catalog=s17181;Integrated Security=True";

        public ObservableCollection<Student> getStudents()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM apbd.STUDENT", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            IdStudent = int.Parse(reader["IdStudent"].ToString()),
                            Name = reader["FirstName"].ToString(),
                            Surname = reader["LastName"].ToString(),
                            Address = reader["Address"].ToString(),
                            IndexNumber = reader["IndexNumber"].ToString(),
                            Study = new Study
                            {
                                IdStudy = int.Parse(reader["IdStudies"].ToString())
                            }
                        });
                    }
                }
                con.Close();
            }
            return getSubjectofStudent(getStudyofStudents(students));
        }

        public ObservableCollection<Student> getStudyofStudents(ObservableCollection<Student> students)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                foreach (var student in students)
                {
                    using (SqlCommand command = new SqlCommand("SELECT  * FROM apbd.Studies WHERE IdStudies =" + student.Study.IdStudy.ToString(), con))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            student.Study.Name = reader["Name"].ToString();
                        }
                    }
                }
                con.Close();
            }
            return students;
        }

        public ObservableCollection<Student> getSubjectofStudent(ObservableCollection<Student> students)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                foreach (var student in students)
                {
                    student.Subject = new List<Subject>();
                    using (SqlCommand command = new SqlCommand("SELECT  * FROM apbd.Student_Subject WHERE IdStudent=" + student.IdStudent, con))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            student.Subject.Add(new Subject { IdSubject = int.Parse(reader["IdSubject"].ToString()) });
                        }
                    }
                }
                con.Close();
            }

            using (SqlConnection con2 = new SqlConnection(connectionString))
            {
                con2.Open();
                foreach (var student in students)
                {
                    foreach (var subject in student.Subject)

                        using (SqlCommand command2 = new SqlCommand("SELECT  * FROM apbd.Subject WHERE IdSubject=" + subject.IdSubject, con2))
                        using (SqlDataReader reader2 = command2.ExecuteReader())
                        {
                            while (reader2.Read())
                            {
                                subject.Name = reader2["Name"].ToString();
                            }
                        }
                }
                con2.Close();
            }

            return students;
        }

        public ObservableCollection<Subject> getSubjects()
        {
            ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT  * FROM apbd.Subject", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        subjects.Add(
                            new Subject
                            {
                                IdSubject = int.Parse(reader["IdSubject"].ToString()),
                                Name = reader["Name"].ToString()
                            });
                    }
                }
                con.Close();
            }
            return subjects;
        }

        public ObservableCollection<Study> getStudies()
        {
            ObservableCollection<Study> studies = new ObservableCollection<Study>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT  * FROM apbd.Studies", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        studies.Add(
                            new Study
                            {
                                IdStudy = int.Parse(reader["IdStudies"].ToString()),
                                Name = reader["Name"].ToString()
                            });
                    }
                }
                con.Close();
            }
            return studies;
        }

        public void deleteStudent(int StudentID)
        {
            using (SqlConnection ConnectionSQL = new SqlConnection(connectionString))
            {
                ConnectionSQL.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM APBD.Student WHERE IdStudent = " + StudentID, ConnectionSQL))
                {
                    command.ExecuteNonQuery();
                }
                ConnectionSQL.Close();
            }
        }

        public void AddStudent(Student student)
        {
            using (SqlConnection ConnectionSQL = new SqlConnection(connectionString))
            {
                ConnectionSQL.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO apbd.Student (FirstName, LastName, Address, IndexNumber, IdStudies) VALUES (@FirstName, @LastName, @Address, @IndexNumber, @IDStudies)", ConnectionSQL))
                {
                    command.Parameters.AddWithValue("@FirstName", student.Name);
                    command.Parameters.AddWithValue("@LastName", student.Surname);
                    command.Parameters.AddWithValue("@Address", student.Address);
                    command.Parameters.AddWithValue("@IndexNumber", student.IndexNumber);
                    command.Parameters.AddWithValue("@IdStudies", student.Study.IdStudy);

                    int affectedRows = command.ExecuteNonQuery();
                }

                ConnectionSQL.Close();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    foreach (var subject in student.Subject)
                    {
                        using (SqlCommand command = new SqlCommand("ADD_STUDENT_SUBJECT", con))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@ID_STUDENT", student.IdStudent);
                            command.Parameters.AddWithValue("@ID_SUBJECT", subject.IdSubject);
                        }
                    }
                    con.Close();
                }

            }
        }

        public void UpdateStudent(Student student, int id)
        {
            using (SqlConnection ConnectionSQL = new SqlConnection(connectionString))
            {
                ConnectionSQL.Open();
                using (SqlCommand command = new SqlCommand("UPDATE apbd.Student SET FirstName = @FirstName, LastName = @LastName, Address = @Address, IndexNumber = @IndexNumber, IdStudies = @IDStudies WHERE IdStudent = " + id, ConnectionSQL))
                {
                    command.Parameters.AddWithValue("@FirstName", student.Name);
                    command.Parameters.AddWithValue("@LastName", student.Surname);
                    command.Parameters.AddWithValue("@Address", student.Address);
                    command.Parameters.AddWithValue("@IndexNumber", student.IndexNumber);
                    command.Parameters.AddWithValue("@IdStudies", student.Study.IdStudy);
                    int affectedRows = command.ExecuteNonQuery();
                }
                ConnectionSQL.Close();
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                foreach (var subject in student.Subject)
                {
                    using (SqlCommand command = new SqlCommand("UPDATE_STUDENT_SUBJECT", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_STUDENT", student.IdStudent);
                        command.Parameters.AddWithValue("@ID_SUBJECT", subject.IdSubject);
                    }
                }
                con.Close();
            }

        }

    }
}
