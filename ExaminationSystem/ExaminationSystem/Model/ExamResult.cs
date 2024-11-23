using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Model
{
    public class ExamResult
    {
        public int Id { get; set; }
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public int Score { get; set; }
        public DateTime SubmitDate { get;set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }

}
