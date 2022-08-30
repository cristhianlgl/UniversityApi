﻿using System.ComponentModel.DataAnnotations;

namespace ApiOpenUniversity.Models
{
    public class User : BaseEntity
    {
        [Required, StringLength(50)]
        public string FirtsName { get; set; } = string.Empty;
        
        [Required, StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
