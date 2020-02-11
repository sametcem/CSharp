using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task10Tekrar.Models;

namespace Task10Tekrar.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Students = GetData();
            return View();
        }

        public ActionResult Delete(int id)
        {
            DeleteStudent(id);

            return Redirect("/Student/Index");
        }

        public ActionResult AddStudentForm()
        {
            ViewBag.Studies = GetStudies();
            return View();
        }

        [HttpPost]
        public ActionResult AddStudentForm(string FirstName, string LastName, string IndexNumber, int studiesId)
        {
            Match match = Regex.Match(IndexNumber, "^s[0-9]+", RegexOptions.IgnoreCase);
            if (FirstName.Length > 2 && LastName.Length > 2 && match.Success && studiesId > 0)
            {
                AddStudent(new Student { FirstName = FirstName, LastName = LastName, IndexNumber = IndexNumber, Study = (new Study { IdStudies = studiesId }) });
                return Redirect("/Student/Index");
            }
            else
            {
                return Redirect("/Student/AddStudentForm");
            }
        }

        public static string ConnectionString = "Data Source=db-mssql;Initial Catalog=s17181;Integrated Security=True";

        public List<Student> GetData()
        {
            List<Student> Students = new List<Student>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                con.Open();

                using (SqlCommand command = new SqlCommand("SELECT  * FROM apbd.Student", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Students.Add(new Student
                        {
                            IDStudent = (int)reader["IdStudent"],
                            FirstName = reader["FirstName"].ToString(),
                            IndexNumber = reader["IndexNumber"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Study = GetStudyByStud((int)reader["IdStudies"])
                        });
                    }
                }
                con.Close();
            }
            return Students;
        }

        public Study GetStudyByStud(int idStud)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM APBD.STUDIES WHERE IdStudies=@Id;", con))
                {
                    command.Parameters.AddWithValue("@Id", idStud);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return new Study
                        {
                            IdStudies = (int)reader["IdStudies"],
                            Name = reader["Name"].ToString()
                        };
                    }
                }
            }
        }

        public static List<Study> GetStudies()
        {
            List<Study> studies = new List<Study>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM APBD.STUDIES;", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        studies.Add(new Study
                        {
                            IdStudies = (int)reader["IdStudies"],
                            Name = reader["Name"].ToString()
                        });
                    studies.Add(new Study
                    {
                        IdStudies = 0,
                        Name = "NONE"
                    });
                }
            }
            return studies;
        }

        public static void AddStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO APBD.STUDENT (FirstName, LastName, IndexNumber, Address, IdStudies) VALUES(@FirstName, @LastName, @IndexNumber, 'nowhere', @IdStudies);", con))
                {
                    command.Parameters.AddWithValue("@FirstName", student.FirstName);
                    command.Parameters.AddWithValue("@LastName", student.LastName);
                    command.Parameters.AddWithValue("@IndexNumber", student.IndexNumber);
                    command.Parameters.AddWithValue("@IdStudies", student.Study.IdStudies);
                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void DeleteStudent(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                con.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM apbd.Student WHERE IdStudent=@Id", con))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}