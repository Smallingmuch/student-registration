using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Models
{
    public class Course:BaseEntity
    {
        [Required]
        public string CourseName { get; set; }
        public int CourseDuration { get; set; }
        public DateTime StartDate { get; set; }
       [Required] public int StudentId { get; set; }
    }
}
