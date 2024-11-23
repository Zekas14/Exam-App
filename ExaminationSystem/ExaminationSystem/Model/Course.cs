using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace ExaminationSystem.Model
{
    [Index(nameof(Name), IsUnique = true)]
    public class Course : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
        public ICollection<Exam> Exams{ get; set; } = new List<Exam>();
        public ICollection<InstructorCourse> InstructorCourses { get; set; } = new List<InstructorCourse>();
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();    
    }
}