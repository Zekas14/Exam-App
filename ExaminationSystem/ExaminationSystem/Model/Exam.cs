using ExaminationSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExaminationSystem.Model
{
    public  class  Exam : BaseModel
    {

        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int MaxGrade {
            get
            {
                return ExamQuestions.Sum(eq=>eq.QuestionScore);
            }
        }
        public int MaxTime { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        [ForeignKey("Instructor")]
        public int InstructorID { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<ExamQuestion> ExamQuestions { get; set; }
        public ICollection<ExamResult> ExamResults { get; set; }
        
    }
   
}
