using ExaminationSystem.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ExaminationSystem.DTO.Choice
{
    public class ChoiceUpdateDto
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
