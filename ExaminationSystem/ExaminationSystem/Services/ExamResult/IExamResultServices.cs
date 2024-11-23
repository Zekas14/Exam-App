using ExaminationSystem.DTO;
using ExaminationSystem.DTO.ExamResults;
using ExaminationSystem.Services.Exams;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ExaminationSystem.Services.Result
{
    public interface IExamResultServices
    {
        public ApiResponseDto<int> Add(ExamResultCreateDto dto);
        public ApiResponseDto<ICollection<ExamResultDto>> ViewResults();
        public ApiResponseDto<ExamResultDto> ViewResultByExam(int ExamId);
    }
}
