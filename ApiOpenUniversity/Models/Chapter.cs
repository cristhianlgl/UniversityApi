using System.ComponentModel.DataAnnotations;

namespace ApiOpenUniversity.Models
{
    public class Chapter : BaseEntity
    {
        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = new Course();


        [Required]
        public string List { get; set; } = string.Empty;
    }
}
