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
        public string TargetAudiences { get; set; } = string.Empty;
        public string Objectives { get; set; } = string.Empty;
        public string Requirements { get; set; } = string.Empty;

    }
}
