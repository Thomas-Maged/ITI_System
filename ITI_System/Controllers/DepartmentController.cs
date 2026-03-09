using ITI_Entities.Models;
using ITI_Entities.Repo;
using ITI_Entities.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using Microsoft.AspNetCore.Authorization;

namespace ITI_System.Controllers
{
    [Authorize]
    public class DepartmentController:Controller
    {
        static ITI_Context db = new ITI_Context();
        DepartmentRepo deptRepo = new DepartmentRepo(db);
        CourseRepo courseRepo = new CourseRepo(db);

        public IActionResult Index()
        {
            var departments = deptRepo.GetAll().ToList();
            return View(departments);
        }

        [Authorize(Roles="Admin")]
        //Show form to create a new department
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Department dept)
        {
            if (ModelState.IsValid)
            {
                deptRepo.Add(dept);
                return RedirectToAction(nameof(Index));
            }
            else{
                return View();
            }
            
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int deptID)
        {
            deptRepo.Delete(deptID);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int DeptID)
        {
            Department department = deptRepo.GetByID(DeptID);
            return View(department);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int DeptID)
        {
            var CoursesToRemove = deptRepo.GetByID(DeptID).Courses.ToList();
            var allCourses = courseRepo.GetAll();
            var CoursesToAdd = allCourses
             .Where(c => !CoursesToRemove.Any(r => r.CrsID == c.CrsID)) // compare by ID
             .ToList();
            ViewBag.coursesToRemove = CoursesToRemove;
            ViewBag.coursesToAdd = CoursesToAdd;
            Department department = deptRepo.GetByID(DeptID);
            return View(department);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(Department dept, int[] idsToAdd, int[] idsToRemove)
        {
            if (ModelState.IsValid)
            {
                // 1. Load the tracked department from DB
        var trackedDept = deptRepo.GetByID(dept.DeptID);

        // 2. Update basic properties from the form
        trackedDept.Name = dept.Name;
        trackedDept.Capacity = dept.Capacity;

        // 3. Remove courses
        foreach (var id in idsToRemove)
        {
            var course = trackedDept.Courses.FirstOrDefault(c => c.CrsID == id);
            if (course != null)
                trackedDept.Courses.Remove(course);
        }

        // 4. Add new courses
        foreach (var id in idsToAdd)
        {
            var course = courseRepo.GetByID(id);
            trackedDept.Courses.Add(course);
        }

        // 5. Save
        db.SaveChanges();
                return View("Index", deptRepo.GetAll());
            }
            else
            {
                Department department = deptRepo.GetByID(dept.DeptID);
                return View(department);
            }
            
        }
    }
}
