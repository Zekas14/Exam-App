using ExaminationSystem.Data;
using ExaminationSystem.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ExaminationSystem.Attributes
{
    public class OneCorrectAnswerPerQuestionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var choice = (Choice)validationContext.ObjectInstance;
            var context = (AppDbContext)validationContext.GetService(typeof(AppDbContext)); 
            var existingChoices = context.Set<Choice>().Where(c => c.QuestionId == choice.QuestionId && c.IsCorrect).ToList();

            if (choice.IsCorrect && existingChoices.Any())
            {
                return new ValidationResult("Only one choice can be marked as correct.");
            }

            return ValidationResult.Success;
        }
    }
}
