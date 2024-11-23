using ExaminationSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ExaminationSystem.Model
{
    public class Choice : BaseModel 
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; } = false;
        [ForeignKey("Questions")]
        public int QuestionId { get; set; }
        [JsonIgnore]
        public Question Question { get; set; }
    }
}
