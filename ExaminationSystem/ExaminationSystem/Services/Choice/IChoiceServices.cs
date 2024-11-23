using ExaminationSystem.Data.Repos;
using ExaminationSystem.DTO;
using ExaminationSystem.DTO.Choice;
using ExaminationSystem.Model;
using ExaminationSystem.Services.Questions;
using ExaminationSystem.ViewModels.Exams;

namespace ExaminationSystem.Services.Choices
{
    public interface IChoiceServices
    {
        public ApiResponseDto<int> Add(ChoiceCreateDto dto);
        public void AddRange(IEnumerable<ChoiceCreateDto> dtos);
        public ApiResponseDto<int> Delete(int id);
        public ApiResponseDto<int> Update(int id,ChoiceUpdateDto dto);
    }
    public class ChoicService(IRepository<Choice> choiceRepository,IQuestionServices questionServices) : IChoiceServices
    {
        private readonly IRepository<Choice> choiceRepository = choiceRepository;
        private readonly IQuestionServices questionServices = questionServices;
        public ApiResponseDto<int> Add(ChoiceCreateDto dto)
        {
            if (!questionServices.IsFound(dto.QuestionId))
            {
                return new(404, "Question Not Found");
            }
            Choice choice = new()
            {
                Text = dto.Text,
                IsCorrect= dto.IsCorrect,
                QuestionId = dto.QuestionId,
            };
            choiceRepository.Add(choice);
            choiceRepository.SaveChanges();
            return new(201, "Choice Created");
        }
        public void AddRange(IEnumerable<ChoiceCreateDto> dtos)
        {
            foreach (var dto in dtos)
            {
                
                choiceRepository.Add(new Choice
                {
                    Text = dto.Text,
                    IsCorrect= dto.IsCorrect,
                    QuestionId = dto.QuestionId,
                });
            }
            choiceRepository.SaveChanges();
        
        }

        public ApiResponseDto<int> Delete(int id)
        {
            if (choiceRepository.IsFound(id))
            {
                var choice = choiceRepository.GetByID(id);

                choiceRepository.Delete(choice);
                choiceRepository.SaveChanges();
                return new(201, "Choice Deleted");
            }
            return new(404, "Choice Not Found");

        }

        public ApiResponseDto<int> Update(int id,ChoiceUpdateDto dto)
        {
            if (choiceRepository.IsFound(id))
            {
                var choice = choiceRepository.GetByID(id);

                choiceRepository.SaveInclude(choice);
                choiceRepository.SaveChanges();
                return new(201, "Choice Updated");
            }
            return new(404, "Choice Not Found");

        }
    }
}
