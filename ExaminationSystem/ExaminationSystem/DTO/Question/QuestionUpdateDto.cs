using System.ComponentModel.DataAnnotations;

namespace ExaminationSystem.DTO.Question
{
    public class QuestionUpdateDto
    {
        public string Body { get; set; }
        [AllowedValues(["easy , Medium , Hard"])]
        public string Level { get; set; }
    }
}
