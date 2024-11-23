using System.ComponentModel.DataAnnotations;
using ExaminationSystem.Attributes;

namespace ExaminationSystem.DTO.Question
{
    public class QuestionCreateDto
    {
        public string Body { get; set; }
        [AllowedValues(["Simple , Medium , Hard"])]
        public string Level { get; set; }
        [MaxArrayLength(4)]
        public Model.Choice[] Choices { get; set; } = new Model.Choice[4];
    }
}
