using ExaminationSystem.Data.Repos;
using ExaminationSystem.DTO;
using ExaminationSystem.DTO.Course;
using ExaminationSystem.Model ;

namespace ExaminationSystem.Services.Courses
{
    public class CourseServices(IRepository<Course> courseRepository) : ICourseServices
    {
        private readonly IRepository<Course> _courseRepository = courseRepository;

        public ApiResponseDto<CreateCourseDto> AddCourse(CreateCourseDto dto)
        {
            Course course = new()
            {
                Name = dto.Name,
                Hours = dto.Hours,
                Description = dto.Description,
            };
            _courseRepository.Add(course);
            _courseRepository.SaveChanges(); ;
            return new(statusCode: 201);
        }

        public ApiResponseDto<int> DeleteCourse(int id)
        {
            var course = _courseRepository.GetByID(id);
            if (_courseRepository.IsFound(id))
            {
                _courseRepository.Delete(course);
                _courseRepository.SaveChanges();
                return new(204);
            }
            return new(404, "Course Not Found");

        }

        public ApiResponseDto<int> ModifyCourse(int id, CourseModifyDto dto)
        {

            if (_courseRepository.IsFound(id))
            {
                var course = new Course()
                {
                    ID = dto.Id,
                    Name = dto.Name,
                    Description = dto.Description,
                    Hours = dto.Hours,
                    UpdatedDate = dto.UpdatedAt

                };

                string[] properties = { nameof(course.Name), nameof(course.Hours), nameof(course.UpdatedDate), nameof(course.Description) };

                _courseRepository.SaveInclude(course, properties);
                _courseRepository.SaveChanges();
                return new(204, "Course Modified Successfully");
            }
            return new(404, "Course Not Found");

        }

        
        /*       public ApiResponseDto<ICollection<GetAllCoursesDto>> GetAllCourses(CreateCourseDto dto)
               {
                   IReadOnlyList<GetAllCoursesDto> data = new List<GetAllCoursesDto>();
                   var courses = _courseRepository.GetAll();

               }
       */
    }
}
