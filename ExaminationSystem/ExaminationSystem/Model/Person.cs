using ExaminationSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace ExaminationSystem.Model
{
    public abstract class Person : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]

        public string Email { get; set; }
        public string PasswordHash { get; set; }
        
        public string Role { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
    }


}
