using ExaminationSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Model
{
    public class ExamAnswerDetails:BaseModel 
    {
        
        [ForeignKey("ExamResult")]
        public int ExamResultId { get; set; }
        public ExamResult ExamResult { get; set; }  
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }  
        [ForeignKey("Choice")]
        public int SelectedChoiceId { get; set; }
        public Choice Choice { get; set; }  


    }

}
