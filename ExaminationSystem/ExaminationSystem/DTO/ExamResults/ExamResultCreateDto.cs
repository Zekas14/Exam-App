using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ExaminationSystem.DTO.ExamResults
{

    public class ExamResultCreateDto
    {
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        [Range(0,100)]
        public int StudentGrade { get; set; }
        public DateTime SubmitDate { get; set; }
    }
}
