using ApiOpenUniversity.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace ApiOpenUniversity.Models
{
    public class Course : BaseEntity
    {
        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(280)]
        public string ShortDescription { get; set; } = string.Empty;

        public string FullDescription { get; set; } = string.Empty;

        [Required]
        public LevelType Level { get; set; } = LevelType.Basic;

        [Required]
        public ICollection<Category> Categories { get; set; } = new List<Category>();

        [Required]
        public ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();

        [Required]
        public ICollection<Student> Students { get; set; } = new List<Student>();

    }
}
