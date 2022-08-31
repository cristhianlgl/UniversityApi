using System.ComponentModel.DataAnnotations;

namespace ApiOpenUniversity.Models
{
    public class Student : BaseEntity
    {
        [Required]
        public string FirtsName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public DateTime Dob { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
