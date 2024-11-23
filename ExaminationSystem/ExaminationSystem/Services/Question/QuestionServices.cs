using ExaminationSystem.Data.Repos;
using ExaminationSystem.DTO;
using ExaminationSystem.DTO.Choice;
using ExaminationSystem.DTO.Question;
using ExaminationSystem.Model;
using ExaminationSystem.Services.Choices;

namespace ExaminationSystem.Services.Questions
{
    public class QuestionServices(IRepository<Question> questionRepository,IChoiceServices choiceServices) : IQuestionServices
    {
        private readonly IRepository<Question> _questionRepository= questionRepository;
        private readonly IChoiceServices choiceServices = choiceServices;

        public bool IsFound(int id) => _questionRepository.IsFound(id);
        public ApiResponseDto<int> Add(QuestionCreateDto dto)
        {
            var question = new Question()
            {
                Body = dto.Body,
                Level= dto.Level,
                CreatedDate = DateTime.Now,
                
            };
            _questionRepository.Add(question);
            _questionRepository.SaveChanges();
            choiceServices.AddRange
                (dto.Choices.Select(c => new ChoiceCreateDto()
                {
                    QuestionId = question.ID,
                    Text = c.Text,
                    IsCorrect = c.IsCorrect,
                })
                );
            return new(201, "Created");
        }

        public ApiResponseDto<int> Delete(int id)
        {
            if (_questionRepository.IsFound(id))
            {
                var question = _questionRepository.GetByID(id);
                _questionRepository.Delete(question);
                _questionRepository.SaveChanges();
                return new(201, "Deleted");
            }
            return new(404, "Question Not Found");
        }

        public ApiResponseDto<int> Update(int id,QuestionUpdateDto dto)
        {
            if (_questionRepository.IsFound(id))
            {
                var question = _questionRepository.GetByID(id);
                _questionRepository.SaveInclude(question,nameof(question.Body), nameof(question.Level));
                _questionRepository.SaveChanges();
                return new(201, "Question Updated");
            }
            return new(404, "Question Not Found");
        }
    }
}
