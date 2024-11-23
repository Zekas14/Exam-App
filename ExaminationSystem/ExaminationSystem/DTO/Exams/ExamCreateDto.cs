using System.ComponentModel.DataAnnotations;

namespace ExaminationSystem.ViewModels.Exams
{

    public class ExamCreateDto
    {
        [AllowedValues(["Quiz", "Final"])]
        public string Type { get; set; }
        [Required]
        [MinLength(15)]
        [MaxLength(180)]
        public int MaxTimeByMinutes { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;
        public int CourseId { get; set; }
        public int InstructorId { get; set; }
        public ICollection<int> QuestionsIds { get; set; }
    }
}
