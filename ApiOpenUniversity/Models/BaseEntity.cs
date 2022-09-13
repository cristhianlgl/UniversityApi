using ApiOpenUniversity.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace ApiOpenUniversity.Models
{
    public class BaseEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public virtual string LastActionBy { get; set; } = string.Empty;
        public ActionModel LastAction { get; set; } = ActionModel.Create;
        public DateTime? LastActionAt { get; set; } = DateTime.Now;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
