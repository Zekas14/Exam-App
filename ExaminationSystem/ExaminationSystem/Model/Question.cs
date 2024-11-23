using ExaminationSystem.Model.Enums;
using ExaminationSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Model
{
    public class Question : BaseModel
    {
        public string Body { get; set; }
        public string Level { get; set; }
        public ICollection<ExamQuestion> ExamQuestions { get; set; }
        public ICollection<Choice> Choices { get; set; } = new List<Choice>();
    }
}
