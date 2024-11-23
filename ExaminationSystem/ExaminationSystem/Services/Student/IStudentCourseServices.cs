using ExaminationSystem.Data.Repos;
using ExaminationSystem.DTO;
using ExaminationSystem.DTO.Course;
using ExaminationSystem.Model;

namespace ExaminationSystem.Services.Students
{
    public interface IStudentCourseServices
    {
       public ApiResponseDto<CourseEnrollDto> EnrollCourse(CourseEnrollDto dto);

    }
    public class StudentCourseServices(IRepository<StudentCourse> studentCourseRepository) : IStudentCourseServices
    {
        private readonly IRepository<StudentCourse> studentCourseRepository = studentCourseRepository;

        public ApiResponseDto<CourseEnrollDto> EnrollCourse(CourseEnrollDto dto)
        {
            StudentCourse studentCourse = new()
            {
                CourseID = dto.CourseId,
                StudentID = dto.StudentId
            };
            studentCourseRepository.Add(studentCourse);
            return new(201, "Course Enrolled");
        }
    }

}
