using Microsoft.AspNetCore.Mvc;
using ITI_Entities;
using ITI_Entities.Repo;
using ITI_Entities.Data;
using ITI_System.Models;
using ITI_Entities.Models;
using ITI_System.Filters;
using Microsoft.AspNetCore.Authorization;


namespace ITI_System.Controllers
{
    [Authorize(Roles ="Admin")]
    public class StudentController : Controller
    {
        StudentRepo studentRepo = new StudentRepo();
        static ITI_Context db = new ITI_Context();
        DepartmentRepo deptRepo = new DepartmentRepo(db);
        public IActionResult Index()
        {
            var students = studentRepo.GetAll();
            return View(students);
        }
        public IActionResult Create()
        {
            ViewBag.Departments = deptRepo.GetAll().ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentCreateViewModel scv)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student();
                student.Name = scv.Name;
                student.Age = scv.Age;
                student.Email = scv.Email;
                student.DeptID = scv.DeptID;
                studentRepo.Add(student);

                var courses = deptRepo.GetByID(scv.DeptID).Courses.ToList();
                foreach (var crs in courses)
                {
                    Course_Student cs = new Course_Student();
                    cs.CrsID = crs.CrsID;
                    cs.StdID = student.ID;
                    db.course_Students.Add(cs);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Departments = deptRepo.GetAll().ToList();
                return View();
            }

        }

        public IActionResult CheckEmail(string Email)
        {
            var exists = studentRepo.GetAll().Any(s => s.Email == Email);
            if (exists)
            {
                return Json("This Email already exist");
            }
            else
            {
                return Json(true);
            }
        }

        public IActionResult Delete(int id)
        {
            var students = studentRepo.GetAll();
            studentRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
