namespace ExaminationSystem.DTO.ExamResults
{
    public class ExamResultDto
    {
        public int ExamId { get; set; } 
        public ICollection<StudentGradeDto> studentGrades { get; set; }
        public string Exam { get; set; }
        public int MinGrade { get; set; }
    }
    public class StudentGradeDto
    {
        public string Student { get; set; }
        public int Grade { get; set; }
        public bool IsSuccess { get; set; }

    }
}
