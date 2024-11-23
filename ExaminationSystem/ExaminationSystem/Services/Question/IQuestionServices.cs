using ExaminationSystem.DTO;
using ExaminationSystem.DTO.Question;

namespace ExaminationSystem.Services.Questions
{
    public interface IQuestionServices
    {
        ApiResponseDto<int> Add(QuestionCreateDto dto);
        ApiResponseDto<int> Delete(int id);
        public bool IsFound(int id);
        ApiResponseDto<int> Update(int id, QuestionUpdateDto dto);
    }
}
