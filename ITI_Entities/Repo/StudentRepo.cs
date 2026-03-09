using ITI_Entities.Data;
using ITI_Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITI_Entities.Repo
{
    public class StudentRepo:IEntityRepo<Student>
    {
        ITI_Context db = new ITI_Context();
        public List<Student> GetAll()
        {
            var students = db.Students.ToList();
            return students;
        }

        public Student GetByID(int id)
        {
            Student student = db.Students.FirstOrDefault(s => s.ID == id);
            return student;
        }
        public void Add(Student s)
        {
            db.Students.Add(s);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            db.Students.Remove(GetByID(id));
            db.SaveChanges();
        }
        public void Update(Student s)
        {
            db.Students.Update(s);
            db.SaveChanges();
        }
    }
}
