using ExaminationSystem.DTO;
using ExaminationSystem.DTO.Course;

namespace ExaminationSystem.Services.Courses
{
    public interface ICourseServices
    {
        public ApiResponseDto<CreateCourseDto> AddCourse(CreateCourseDto dto);
        // public ApiResponseDto<ICollection<GetAllCoursesDto>> GetAllCourses(CreateCourseDto dto);
        public ApiResponseDto<int> DeleteCourse(int id);
        public ApiResponseDto<int> ModifyCourse(int id, CourseModifyDto dto);
    }
}
