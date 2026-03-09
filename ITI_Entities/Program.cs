using ITI_Entities.Data;
using ITI_Entities.Models;
using ITI_Entities.Repo;

public class MyClass
{
    public static void Main(string[] args)
    {
        StudentRepo stdRepo = new StudentRepo();
        //Student s = new Student() { Name = "Hussein", Age = 24, DeptID = 2 };
        //stdRepo.Add(s);
        //var students = stdRepo.GetAll();
        //foreach (var item in students)
        //{
        //    Console.WriteLine(item.Name);
        //}
        //Console.WriteLine("###################");
        //Student s = stdRepo.GetByID(1);
        //s.Name = "Aly";
        //stdRepo.Update(s);

        //students = stdRepo.GetAll();
        //foreach (var item in students)
        //{
        //    Console.WriteLine(item.Name);
        //}
        //Console.WriteLine("###################");

        //stdRepo.Delete(2);
        //students = stdRepo.GetAll();
        //foreach (var item in students)
        //{
        //    Console.WriteLine(item.Name);
        //}

        //DepartmentRepo deptRepo = new DepartmentRepo();
        //Department department = new Department() { Name = "OS", Capacity = 40 };
        //deptRepo.Add(department);

        //CourseRepo courseRepo = new CourseRepo();
        //Course course = new Course() { Name = "Linq", Duration = 16 };
        //courseRepo.Add(course);

        //ITI_Context db = new ITI_Context();
        //Course c = db.Courses.FirstOrDefault(c=>c.CrsID==1);
        //Department d = db.Departments.FirstOrDefault(d=>d.DeptID==2);
        //d.Courses.Add(c);
        //db.SaveChanges();
        
    }
}