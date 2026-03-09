using ITI_Entities.Models;

namespace ITI_System.Models
{
    public class StudentDegree
    {
        public Student Key { get; set; }
        public int Value { get; set; }
    }
    public class EditDegreesForCourseViewModel
    {
        public Course Course { get; set; }
        //public List<Student> Students { get; set; }
        public List<StudentDegree> Degrees { get; set; }
        //public List<Dictionary<Student,int>> StudentDegrees { get; set; }

    }
}
