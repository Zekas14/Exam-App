using ExaminationSystem.Data.Repos;
using ExaminationSystem.DTO;
using ExaminationSystem.DTO.ExamResults;
using ExaminationSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Services.Result
{
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
        private IQueryable<ExamResultDto> ViewAllResults()
        {
            return resultRepository.GetAllWithIncludes(e => e
           .Include(er => er.Student)
           .Include(er => er.Exam))
           .Select(er => new ExamResultDto
           {
               Exam = er.Exam.Name,
               MinGrade = er.Exam.MaxGrade / 2,
               studentGrades = er.Exam.ExamResults.Select(e=>new StudentGradeDto
               {
                   Student = e.Student.Name,
                   Grade = e.Grade,
                   IsSuccess = e.Grade<e.Exam.MaxGrade/2

               }).ToList()
           });
        }
        public ApiResponseDto<ExamResultDto> ViewResultByExam(int examId)
        {
            var result = ViewAllResults().FirstOrDefault(er=>er.ExamId == examId);

            return new(statusCode: 200, data: result);
        }

        public ApiResponseDto<ICollection<ExamResultDto>> ViewResults()
        {
            var results = ViewAllResults().ToList();
            return new(statusCode :200,data: results);
        }
    }
}
