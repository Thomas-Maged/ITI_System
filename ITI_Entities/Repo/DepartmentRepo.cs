using ITI_Entities.Data;
using ITI_Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITI_Entities.Repo
{
    public class DepartmentRepo:IEntityRepo<Department>
    {
        ITI_Context db;
        public DepartmentRepo(ITI_Context _db)
        {
            db = _db;
        }
        public List<Department> GetAll()
        {
            var departments = db.Departments.ToList();
            return departments;
        }
        public Department GetByID(int id)
        {
            Department department = db.Departments.Include(d => d.Courses).Include(d=>d.Students).FirstOrDefault(d => d.DeptID == id);
            return department;
        }
        public Department GetByIDNoTracking(int id)
        {
            return db.Departments
                     .Include(d => d.Courses)
                     .AsNoTracking()
                     .FirstOrDefault(d => d.DeptID == id);
        }
        public void Add(Department d)
        {
            db.Departments.Add(d);
            db.SaveChanges();
        }
        public void Update(Department d)
        {
            db.Departments.Update(d);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            db.Departments.Remove(GetByID(id));
            db.SaveChanges();
        }
    }
}
