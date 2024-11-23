using ExaminationSystem.Data.Repos;
using ExaminationSystem.DTO;
using ExaminationSystem.DTO.Course;
using ExaminationSystem.Model;
using ExaminationSystem.Services.Courses;
using ExaminationSystem.Services.Students;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(ICourseServices courseServices, IStudentCourseServices studentCourseServices) : ControllerBase
    {
        private readonly ICourseServices courseServices= courseServices;
        private readonly IStudentCourseServices studentCourseServices=studentCourseServices;
        

        [HttpPost]
        
        public IActionResult Create(CreateCourseDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = courseServices.AddCourse(dto);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public ApiResponseDto<int> DeleteCourse(int id)
        {
            return courseServices.DeleteCourse(id);
        }
        [HttpPut] 
        public ApiResponseDto<int> ModifyCourse(int id , CourseModifyDto dto)
        {
            if(ModelState.IsValid)
            {
                return courseServices.ModifyCourse(id,dto);
            }
            return new(400, ModelState);
        }
        [HttpPost("EnrollCourse")]
        public ApiResponseDto<CourseEnrollDto> EnrollCourse(CourseEnrollDto dto)
            => ModelState.IsValid ? studentCourseServices.EnrollCourse(dto) : new(400, ModelState);
        
    }
}
