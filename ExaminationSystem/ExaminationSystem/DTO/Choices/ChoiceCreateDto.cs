using ExaminationSystem.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.DTO.Choice
{
    public class ChoiceCreateDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Text { get; set; }
        [AllowedValues(["true", "false"])]
        [OneCorrectAnswerPerQuestion]
        public bool IsCorrect { get; set; } = false;
        public int QuestionId { get; set; }

    }
}
