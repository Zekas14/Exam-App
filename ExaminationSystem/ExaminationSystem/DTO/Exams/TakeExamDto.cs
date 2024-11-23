namespace ExaminationSystem.ViewModels.Exams
{
    public class TakeExamDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<QuestionDto> Questions { get; set; }
    }

    public class QuestionDto
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public List<ChoiceDto> Choices { get; set; }
    }

    public class ChoiceDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
