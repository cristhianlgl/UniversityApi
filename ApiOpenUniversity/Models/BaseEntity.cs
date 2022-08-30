using System.ComponentModel.DataAnnotations;

namespace ApiOpenUniversity.Models
{
    public class BaseEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public string DeletedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeleteAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
