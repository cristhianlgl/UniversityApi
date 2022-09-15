﻿using System.ComponentModel.DataAnnotations;

namespace ApiOpenUniversity.Models
{
    public class UserLogin
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
