using System.ComponentModel.DataAnnotations;

namespace ExaminationSystem.Model
{
    public class Student :Person
    {
        [Required]
        [MinLength(0)]
        public int Grade { get; set; }
        [Range(10,25)]
        public int Age { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }= new List<StudentCourse>();
    }


}
