using ITI_Entities.Data;
using ITI_Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITI_Entities.Repo
{
    public class CourseRepo:IEntityRepo<Course>
    {
        ITI_Context db;
        public CourseRepo(ITI_Context _db)
        {
            db = _db;
        }
        public List<Course> GetAll()
        {
            var courses = db.Courses.ToList();
            return courses;
        }
        public Course GetByID(int id)
        {
            Course course = db.Courses.Include(c=>c.Departments).FirstOrDefault(c => c.CrsID == id);
            return course;
        }
        public void Add(Course c)
        {
            db.Courses.Add(c);
            db.SaveChanges();
        }
        public void Update(Course c)
        {
            db.Courses.Update(c);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            db.Courses.Remove(GetByID(id));
            db.SaveChanges();
        }
    }
}
