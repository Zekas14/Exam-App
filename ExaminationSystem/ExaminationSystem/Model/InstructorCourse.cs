using ExaminationSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Model
{
    public class InstructorCourse:BaseModel
    {

        [ForeignKey("Instructor")]
        public int InstructorID { get; set; }
        [ForeignKey("Course")]
        public int CourseID { get; set; }

        public Instructor Instructor { get; set; }

        public Course Course { get; set; }

    }

}
