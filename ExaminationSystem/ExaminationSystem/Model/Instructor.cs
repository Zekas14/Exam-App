namespace ExaminationSystem.Model
{
    public class Instructor : Person
    {
        public ICollection<InstructorCourse> InstructorCourses { get; set; }
    }


}
