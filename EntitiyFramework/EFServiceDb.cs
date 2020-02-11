using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiyFramework.Models;

namespace EntitiyFramework
{
    public class EfServiceDb
    {
        public List<Student> GetStudents()
        {
            using (var context = new StudentDbContext())
            {
                var students = context.Students.ToList();
                return students;
            }
        }

        public Student AddStudent(Student newStudent)
        {
            using (var context = new StudentDbContext())
            {
                context.Students.Add(newStudent);
                //...
                context.SaveChanges(); //...INSERT

                return newStudent; //id=1
            }
        }

        public void RemoveStudent(Student studentToRemove)
        {
            using (var context = new StudentDbContext())
            {
                context.Students.Attach(studentToRemove);
                context.Students.Remove(studentToRemove);
                context.SaveChanges();
            }
        }

        public void UpdateStudent(Student studentToUpdate)
        {
          

        }

    }
}
