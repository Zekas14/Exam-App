using ExaminationSystem.DTO;
using ExaminationSystem.Services.Exams;
using ExaminationSystem.ViewModels.Exams;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController(IExamService examService) : ControllerBase
    {
        private readonly IExamService _examService = examService;
        [HttpGet("TakeExam")]
        public ApiResponseDto<TakeExamDto> TakeExam(int examId)
        {
            return _examService.TakeExam(examId);
        }

        [HttpPost("Create")]
        public ApiResponseDto<int> CreateExam(ExamCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = _examService.Add(dto);
                return result;
            }
            return new(400, ModelState);

        }
        [HttpDelete("Delete")]
        public ApiResponseDto<int> DeleteExam(int id)
        {
            var result = _examService.Delete(id);
            return result;
        }
        [HttpPut("Edit")]
        public ApiResponseDto<int> EditExam(int id, ExamUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = _examService.Update(id, dto);
                return result;
            }
            return new(400, ModelState);
        }
        [HttpPost("AddQuestionToExam")]
        public ApiResponseDto<int> AddQuestionToExam(ExamQuestionCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                var result =_examService.AddQuestionToExam(dto);
                return result;
            }
            return new (statusCode:400, message : ModelState) ;
        }
    }
}