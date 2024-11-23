using System.ComponentModel.DataAnnotations;

namespace ExaminationSystem.DTO.Course
{
    public class CourseModifyDto
    {
        public int Id { get;}

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Name { get; set; }
        [Required]
        [MinLength(10)]
        public string Description { get; set; }
        [Range(1, 4)]
        public int Hours { get; set; }
        public DateTime UpdatedAt { get; set; }= DateTime.Now;  

    }
}
