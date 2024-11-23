using ExaminationSystem.Data.Repos;
using ExaminationSystem.DTO;
using ExaminationSystem.Model;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Exams;

namespace ExaminationSystem.Services.ExamQuestions
{
    public class ExamQuestionService(IRepository<ExamQuestion> examQuestionRepo) : IExamQuestionService
    {
        IRepository<ExamQuestion> _examQuestionRepository= examQuestionRepo;

       

        public ApiResponseDto<int> Add(ExamQuestionCreateDto dto)
        {
            _examQuestionRepository.Add(new ExamQuestion
            {
                ExamID = dto.ExamID,
                QuestionID = dto.QuestionID,
            });

            _examQuestionRepository.SaveChanges();
           return new(201, "Quetion Added To Exam");
        }

        public void AddRange(IEnumerable<ExamQuestionCreateDto> dtos)
        {
            foreach (var dto in dtos)
            {
                _examQuestionRepository.Add(new ExamQuestion
                {
                    ExamID = dto.ExamID,
                    QuestionID = dto.QuestionID,
                });
            }

            _examQuestionRepository.SaveChanges();
        }
    }
}
