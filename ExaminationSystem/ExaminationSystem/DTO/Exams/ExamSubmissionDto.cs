namespace ExaminationSystem.ViewModels.Exams
{
    public class ExamSubmissionDto
    {
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public List<ExamAnswerDto> Answers { get; set; }
    }

    public class ExamAnswerDto
    {
        public int QuestionId { get; set; }
        public int SelectedChoiceId { get; set; }
    }
    public class ExamAnswersDetailsDto
    {
        public string Question { get; set; }
        public string SelectedChoice { get; set; }

    }
   
}
