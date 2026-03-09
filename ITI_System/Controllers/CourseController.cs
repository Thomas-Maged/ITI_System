using ITI_Entities.Data;
using ITI_Entities.Models;
using ITI_Entities.Repo;
using ITI_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITI_System.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        ITI_Context db;
        CourseRepo crsRepo;
        DepartmentRepo deptRepo;
        public CourseController()
        {
            db = new ITI_Context();
            crsRepo = new CourseRepo(db);
            deptRepo = new DepartmentRepo(db);
        }
        public IActionResult Index()
        {
            var courses = crsRepo.GetAll();
            return View(courses);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Course crs)
        {
            if (ModelState.IsValid)
            {
                crsRepo.Add(crs);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int crsID)
        {
            crsRepo.Delete(crsID);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int crsID)
        {
            Course course = crsRepo.GetByID(crsID);
            return View(course);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int crsID)
        {
            Course course = crsRepo.GetByID(crsID);
            return View(course);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                var crs = db.Courses.FirstOrDefault(c => c.CrsID == course.CrsID);
                crs.Name = course.Name;
                crs.Duration = course.Duration;
                db.SaveChanges();
                return View("Index", crsRepo.GetAll());
            }
            else
            {
                Course crs = crsRepo.GetByID(course.CrsID);
                return View(crs);
            }
            
        }

        [Authorize(Roles = "Instructor")]
        public IActionResult EditDegrees(int crsID)
        {
            EditDegreesForCourseViewModel courseDegrees = new EditDegreesForCourseViewModel();
            //ids of all the departments in this course
            List<int> deptsID = crsRepo.GetByID(crsID).Departments.Select(d => d.DeptID).ToList();

            //Collect all students in departments in one list 
            List<Student> AllStudentInCourse = new List<Student>();
            foreach (int id in deptsID)
            {
                //get the students of each department and add it to the main List
                List<Student> students = deptRepo.GetByID(id).Students.ToList();
                AllStudentInCourse.AddRange(students);
            }
            courseDegrees.Course = crsRepo.GetByID(crsID);
            courseDegrees.Degrees = new List<StudentDegree>();
            foreach (Student std in AllStudentInCourse)
            {
                Course_Student course_student = db.course_Students.FirstOrDefault(cs => cs.CrsID == crsID && cs.StdID == std.ID);
                StudentDegree studentDegree = new StudentDegree();
                studentDegree.Key = std;
                studentDegree.Value = course_student.Grade ?? 0;

                courseDegrees.Degrees.Add(studentDegree);
            }
            return View(courseDegrees);
        }

        [Authorize(Roles = "Instructor")]
        [HttpPost]
        public IActionResult EditDegrees(EditDegreesForCourseViewModel model)
        {
            foreach (var degree in model.Degrees)
            {
                var cs = db.course_Students.FirstOrDefault(c => c.StdID == degree.Key.ID && c.CrsID == model.Course.CrsID);
                cs.Grade = degree.Value;
                db.SaveChanges();
            }
            return RedirectToAction("EditDegrees",new { crsID = model.Course.CrsID });
        }
    }
}
