using ExaminationSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Model
{
    public class StudentCourse :BaseModel
    {

        public int ID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }
        [ForeignKey("Course")]
        public int CourseID { get; set; }

        public Student Student { get; set; }

        public Course Course { get; set; }

    }
}
