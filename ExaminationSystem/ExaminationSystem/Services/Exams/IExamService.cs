using ExaminationSystem.DTO;
using ExaminationSystem.ViewModels.Exams;

namespace ExaminationSystem.Services.Exams
{
    public interface IExamService
    {
        ApiResponseDto<int> Add(ExamCreateDto dto);
        ApiResponseDto<int> Delete(int id);
        ApiResponseDto<int> Update(int id, ExamUpdateDto dto);
        ApiResponseDto<int> AddQuestionToExam(ExamQuestionCreateDto dto);
        ApiResponseDto<TakeExamDto> TakeExam(int examId);
    }
}
