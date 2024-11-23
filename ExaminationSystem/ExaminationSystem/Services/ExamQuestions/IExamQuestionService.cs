using ExaminationSystem.DTO;
using ExaminationSystem.ViewModels.Exams;

namespace ExaminationSystem.Services.ExamQuestions
{
    public interface IExamQuestionService
    {
        ApiResponseDto<int> Add(ExamQuestionCreateDto question);
        void AddRange(IEnumerable<ExamQuestionCreateDto> questions);
    }
}
