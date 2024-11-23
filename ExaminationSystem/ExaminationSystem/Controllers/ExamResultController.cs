using ExaminationSystem.DTO;
using ExaminationSystem.DTO.ExamResults;
using ExaminationSystem.Services.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamResultController(IExamResultServices examResultServices) : ControllerBase
    {
        private readonly IExamResultServices examResultServices = examResultServices;

        [HttpGet("ViewAllResults")]
        public ApiResponseDto<ICollection<ExamResultDto>> ViewAllResults()
        {
            return examResultServices.ViewResults();
        }
        [HttpGet("ViewExamResults")]
        public ApiResponseDto<ExamResultDto> ViewAllResults(int examId)
        {
            return examResultServices.ViewResultByExam(examId);
        }
    }
}
