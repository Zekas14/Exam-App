using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.DTO.Course
{
    [NotMapped]
    public class GetAllCoursesDto
    {

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Name { get; set; }
        [Required]
        [MinLength(10)]
        public string Description { get; set; }
        [Range(1,4)]
        public int Hours { get; set; }

    }
}
