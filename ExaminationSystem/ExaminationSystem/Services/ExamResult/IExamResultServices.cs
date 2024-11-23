using ExaminationSystem.Data.Repos;
using ExaminationSystem.DTO;
using ExaminationSystem.DTO.ExamResults;
using ExaminationSystem.Model;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ExaminationSystem.Services.Result
{
    public interface IExamResultServices
    {
        public ApiResponseDto<int> Add(ExamResultCreateDto dto);
    }
    public class ExamResultServices(IRepository<ExamResult> resultRepository) : IExamResultServices
    {
        private readonly IRepository<ExamResult> resultRepository = resultRepository;

        public ApiResponseDto<int> Add(ExamResultCreateDto dto)
        {
            ExamResult examResult = new()
            {
                StudentId = dto.StudentId,
                ExamId = dto.ExamId,
                SubmitDate =dto.SubmitDate,
                Grade=dto.StudentGrade
            };
            resultRepository.Add(examResult);
            resultRepository.SaveChanges();
            return new(statusCode: 201, message: "Created");
        }
    }
}
