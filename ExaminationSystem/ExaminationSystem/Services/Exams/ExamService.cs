﻿
using ExaminationSystem.Data.Repos;
using ExaminationSystem.DTO;
using ExaminationSystem.Model;
using ExaminationSystem.Services.ExamQuestions;
using ExaminationSystem.ViewModels.Exams;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Services.Exams
{
    public class ExamService(IRepository<Exam> examRepository, IExamQuestionService examQuestionService) : IExamService
    {
        private readonly IRepository<Exam> _examRepository = examRepository;
        private readonly IExamQuestionService _examQuestionService = examQuestionService;



        public ApiResponseDto<int> Add(ExamCreateDto dto)
        {

            var exam = new Exam
            {
                Type = dto.Type,
                Date= dto.Date,
                CourseId=dto.CourseId,
              InstructorID= dto.InstructorId  
            };

            _examRepository.Add(exam);

            _examRepository.SaveChanges();

            _examQuestionService.AddRange(dto.QuestionsIds
                .Select(x => new ExamQuestionCreateDto
                {
                    ExamID = exam.ID,
                    QuestionID = x
                }));

            return new(201,"Created");
        }

        public ApiResponseDto<int> AddQuestionToExam(ExamQuestionCreateDto dto)
        {
            if (_examRepository.IsFound(dto.ExamID))
            {
               var result = _examQuestionService.Add(dto);
            return result ;
            }
            return new(404, "Exam Not Found");
        }

        public ApiResponseDto<int> Delete(int id)
        {
            if (_examRepository.IsFound(id))
            {
                var exam = _examRepository.GetByID(id);
                _examRepository.Delete(exam);
                _examRepository.SaveChanges();
                return new(204, "Exam Deleted ");
            }
            return new(404, "Exam Not Found");
        }

        public ApiResponseDto<TakeExamDto> TakeExam(int examId)
        {
            if (!_examRepository.IsFound(examId))
            {
                return new(404, "Exam Not Found");
            }
            var exam = _examRepository.GetAllWithIncludes(e=>
           e.Include(ex => ex.ExamQuestions)
            .ThenInclude(eq => eq.Question))
            .FirstOrDefault(e => e.ID == examId);

            TakeExamDto dto = new TakeExamDto()
            {
                Id = exam.ID,
                Questions = exam.ExamQuestions.Select(e => new QuestionDto()
                {
                    Id = e.ID,
                    Body = e.Question.Body,
                    Choices = e.Question.Choices.Select(
                       c => new ChoiceDto()
                       {
                           Id = c.ID,
                           Text = c.Text,
                       }
                       ).ToList(),
                }
                ).ToList()
            };
            return new(200,dto);
        }

        public ApiResponseDto<int> Update(int id, ExamUpdateDto dto)
        {
            if (_examRepository.IsFound(id))
            {
                Exam exam = new()
                {
                    ID = dto.Id,
                    Type = dto.Type,
                    MaxTime = dto.MaxTimeByMinutes,
                    Date = dto.Date
                };
                _examRepository.SaveInclude(exam, nameof(exam.Type), nameof(exam.Type), nameof(exam.Date));
                _examRepository.SaveChanges();
                return new(204, "Exam Updated");
            }
            return new(404, "Exam Not Found");
        }
    }
}