namespace ExaminationSystem.ViewModels.Exams
{
    public class ExamUpdateDto
    {
        public int Id { get; set; }
        public int MaxTimeByMinutes { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
